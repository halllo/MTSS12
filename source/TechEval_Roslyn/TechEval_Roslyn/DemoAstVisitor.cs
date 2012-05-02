using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Roslyn.Compilers.CSharp;

namespace TechEval_Roslyn
{
    class DemoAstVisitor : SyntaxWalker
    {
        protected override void VisitIfStatement(IfStatementSyntax node)
        {
            base.VisitIfStatement(node);
        }

        protected override void VisitInvocationExpression(InvocationExpressionSyntax node)
        {
            base.VisitInvocationExpression(node);
        }

        public int Lines { get; private set; }
        protected override void VisitTrivia(SyntaxTrivia trivia)
        {
            if (trivia.Kind == SyntaxKind.EndOfLineTrivia) Lines++;
            base.VisitTrivia(trivia);
        }

        protected override void VisitTrailingTrivia(SyntaxToken token)
        {
            base.VisitTrailingTrivia(token);
        }
    }
}
