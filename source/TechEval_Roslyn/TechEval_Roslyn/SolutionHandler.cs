using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Roslyn.Services;
using Roslyn.Compilers.CSharp;
using Roslyn.Compilers.Common;

namespace TechEval_Roslyn
{
    class SolutionHandler
    {
        public static void Analyse(string solutionFile)
        {
            var ws = Workspace.LoadSolution(solutionFile);
            var solution = ws.CurrentSolution;
            foreach (var document in solution.Projects.SelectMany(p => p.Documents))
            {
                HandleDocument(document);
            }
        }

        private static void HandleDocument(IDocument document)
        {
            Console.WriteLine(document.DisplayName);
            var tree = document.GetSyntaxTree();
            var sema = document.GetSemanticModel();

            //HandleCompilation(sema.Compilation);
            
            var methods = tree.Root.DescendentNodes().OfType<MethodDeclarationSyntax>();
            foreach (var method in methods)
            {
                HandleMethod(sema, method);
            }
        }

        private static void HandleCompilation(ICompilation compilation)
        {
            var ns = compilation.GlobalNamespace;
            foreach (var type in ns.GetTypeMembers())
            {
                Console.WriteLine(type.Name);
                foreach (var member in type.GetMembers())
                {
                    Console.WriteLine("\t" + member.Name);
                }
            }
        }

        private static void HandleMethod(ISemanticModel sema, MethodDeclarationSyntax method)
        {
            Console.WriteLine("\t" + method.Identifier.ValueText);
            
            HandleStatements(method);
            HandleConditions(method);
            HandleMethodLength(method);
            HandleDeclarations(method);

            HandleInvocations(sema, method);
            HandleConstructorInvocations(sema, method);
        }

        private static void HandleMethodLength(MethodDeclarationSyntax method)
        {
            var methodVisit = new DemoAstVisitor();
            methodVisit.Visit(method);
            Console.WriteLine("\t\t\tml: " + (methodVisit.Lines - 1));
        }

        private static void HandleConditions(MethodDeclarationSyntax method)
        {
            int cc = 1;
            var ifs = method.DescendentNodes().OfType<IfStatementSyntax>();
            foreach (var cond in ifs)
            {
                var bins = cond.Condition.DescendentNodesAndSelf().OfType<BinaryExpressionSyntax>();
                cc += 1 + bins.Count();
            }
            Console.WriteLine("\t\t\tcc: " + cc);
        }

        private static void HandleInvocations(ISemanticModel sema, MethodDeclarationSyntax method)
        {
            var invocations = method.DescendentNodes().OfType<InvocationExpressionSyntax>();
            foreach (var invocation in invocations)
            {
                var invocSymbols = sema.GetSemanticInfo(invocation);
                Console.WriteLine("\t\t\ti: " + invocSymbols.Symbol.ContainingType.Name);
            }
        }

        private static void HandleConstructorInvocations(ISemanticModel sema, MethodDeclarationSyntax method)
        {
            var ctors = method.DescendentNodes().OfType<ObjectCreationExpressionSyntax>();
            foreach (var ctor in ctors)
            {
                var ctorSymbols = sema.GetSemanticInfo(ctor);
                Console.WriteLine("\t\t\tc: " + ctorSymbols.Symbol.ContainingType.Name);
            }
        }

        private static void HandleDeclarations(MethodDeclarationSyntax method)
        {
            var declarations = method.DescendentNodes().OfType<VariableDeclarationSyntax>();
            foreach (var declaration in declarations)
            {
                Console.WriteLine("\t\t\td: " + declaration.Type.PlainName);
            }
        }

        private static void HandleStatements(MethodDeclarationSyntax method)
        {
            var statements = method.DescendentNodes().OfType<StatementSyntax>();
            Console.WriteLine("\t\t\tns: " + statements.Count(s => !(s is BlockSyntax)));
        }
    }
}
