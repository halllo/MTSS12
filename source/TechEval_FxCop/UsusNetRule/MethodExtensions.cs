using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.FxCop.Sdk;

namespace UsusNetRule
{
    internal static class MethodExtensions
    {
        public static IList<Method> Callees(this Method caller)
        {
            MethodVisitor cv = new MethodVisitor();
            cv.VisitStatements(caller.Body.Statements);
            return cv.Callees;
        }

        public static IList<TypeNode> ReferencedTypes(this Method caller)
        {
            return Callees(caller).Select(m => m.DeclaringType).Distinct().ToList();
        }

        public static int CyclomaticComplexity(this Method caller)
        {
            MethodVisitor cv = new MethodVisitor();
            cv.VisitStatements(caller.Body.Statements);
            return cv.Cc;
        }

        public static int NumberOfLines(this Method caller)
        {
            var allStatements = caller.Body.Statements.SelectManyRecursive(s => Enumerable.Repeat(s, 1), (Block b) => b.Statements).ToList();
            int latestEndline = allStatements.Max(s => s.SourceContext.EndLine);
            int earliestStartline = allStatements.Min(s => s.SourceContext.StartLine);
            return Math.Max(0, (latestEndline - earliestStartline) - 1);
        }
    }
}