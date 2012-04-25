using System;
using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.CSharp.Resolver;

namespace TechEval_NRefactory
{
    public class MethodCalls
    {
        private readonly DefaultResolver _Resolver;

        public MethodCalls(DefaultResolver resolver)
        {
            _Resolver = resolver;
        }

        public void Output(InvocationExpression invocationExpression)
        {
            GetResolved(invocationExpression, r => OutputMethodCall(r));
        }

        private static void OutputMethodCall(CSharpInvocationResolveResult resolved)
        {
            Console.WriteLine(String.Format("\t\t\tmethod call to ({0}.){1} but on {2}",
                resolved.TargetResult.Type.FullName, 
                resolved.Member.Name,
                resolved.Member.FullName));
        }

        private void GetResolved(InvocationExpression invocationExpression, Action<CSharpInvocationResolveResult> resolved)
        {
            if (_Resolver.resolveResults.ContainsKey(invocationExpression))
            {
                var result = _Resolver.resolveResults[invocationExpression] as CSharpInvocationResolveResult;
                if (result != null) resolved(result);
            }
        }
    }
}
