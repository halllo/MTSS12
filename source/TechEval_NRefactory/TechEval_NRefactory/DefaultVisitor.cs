using System;
using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;

namespace TechEval_NRefactory
{

    public class DefaultVisitor : DepthFirstAstVisitor
    {
        MethodCalls methodCalls;

        public DefaultVisitor(DefaultResolver resolved)
        {
            methodCalls = new MethodCalls(resolved);
        }

        public override void VisitNamespaceDeclaration(NamespaceDeclaration namespaceDeclaration)
        {
            Console.WriteLine(namespaceDeclaration.Name);
            base.VisitNamespaceDeclaration(namespaceDeclaration);
        }

        public override void VisitTypeDeclaration(TypeDeclaration typeDeclaration)
        {
            Console.WriteLine("\t" + typeDeclaration.Name);
            base.VisitTypeDeclaration(typeDeclaration);
        }

        public override void VisitMethodDeclaration(MethodDeclaration methodDeclaration)
        {
            Console.WriteLine("\t\t" + methodDeclaration.Name);
            base.VisitMethodDeclaration(methodDeclaration);
            Console.WriteLine();
        }

        public override void VisitNewLine(NewLineNode newLineNode)
        {
            base.VisitNewLine(newLineNode);
        }

        public override void VisitInvocationExpression(InvocationExpression invocationExpression)
        {
            methodCalls.Output(invocationExpression);
            base.VisitInvocationExpression(invocationExpression);
        }

        public override void VisitMemberReferenceExpression(MemberReferenceExpression memberReferenceExpression)
        {
            base.VisitMemberReferenceExpression(memberReferenceExpression);
        }

        public override void VisitPrimitiveExpression(PrimitiveExpression primitiveExpression)
        {
            base.VisitPrimitiveExpression(primitiveExpression);
        }

        public override void VisitIfElseStatement(IfElseStatement ifElseStatement)
        {
            base.VisitIfElseStatement(ifElseStatement);
        }

        public override void VisitBinaryOperatorExpression(BinaryOperatorExpression binaryOperatorExpression)
        {
            base.VisitBinaryOperatorExpression(binaryOperatorExpression);
        }
    }
}