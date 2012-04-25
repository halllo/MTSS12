using System;
using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.TypeSystem;
using ICSharpCode.NRefactory.CSharp.Resolver;
using ICSharpCode.NRefactory.CSharp.TypeSystem;

namespace TechEval_NRefactory
{
    public static class NRefactoryTries
    {
        public static void ReadAndParseFile(string file)
        {
            EmbeddedResource.Read(file, c => Parse(c, ast =>
            {
                var resolved = Resolve(ast);
                ast.AcceptVisitor(new DefaultVisitor(resolved));
            }));
        }

        private static void Parse(string toParse, Action<CompilationUnit> ast)
        {
            var parser = new CSharpParser();
            CompilationUnit parsed = parser.Parse(toParse, "Code1");
            ast(parsed);
        }

        private static DefaultResolver Resolve(CompilationUnit parsed)
        {
            CSharpAstResolver resolver = CreateResolver(parsed, typeof(object));
            DefaultResolver navigator = new DefaultResolver();
            resolver.ApplyNavigator(navigator);
            return navigator;
        }

        private static CSharpAstResolver CreateResolver(CompilationUnit parsed, params Type[] types)
        {
            IProjectContent project = new CSharpProjectContent();
            CSharpParsedFile parsedFile = parsed.ToTypeSystem();
            project = project.UpdateProjectContent(null, parsedFile);
            project = project.AddAssemblyReferences(LoadAssemblies(types));
            return new CSharpAstResolver(project.CreateCompilation(), parsed, parsedFile);
        }
        
        private static IEnumerable<IUnresolvedAssembly> LoadAssemblies(params Type[] types)
        {
            var loader = new CecilLoader();
            return types.Select(t => loader.LoadAssemblyFile(t.Assembly.Location));
        }
    }
}