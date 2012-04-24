using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using ICSharpCode.NRefactory.CSharp;

namespace TechEval_NRefactory
{
    public static class NRefactoryTries
    {
        public static void ReadAndParseFile(string file)
        {
            EmbeddedResource.Read(file, c => Parse(c, ast =>
            {
                ast.AcceptVisitor(new DefaultVisitor());
            }));
        }
        private static void Parse(string toParse, Action<AstNode> ast)
        {
            var parser = new CSharpParser();
            ast(parser.Parse(toParse, "Code1"));
        }
    }
}