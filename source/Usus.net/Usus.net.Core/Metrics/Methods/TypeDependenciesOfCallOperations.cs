using System.Collections.Generic;
using Microsoft.Cci;

namespace andrena.Usus.net.Core.Metrics.Methods
{
    internal static class TypeDependenciesOfCallOperations
    {
        public static IEnumerable<string> Of(IMethodDefinition method)
        {
            return method.OperationTypes(
                o => o.IsCallOperation(), 
                o => o.CalleeTypes());
        }

        private static bool IsCallOperation(this OperationCode o)
        {
            return o == OperationCode.Call
                || o == OperationCode.Calli
                || o == OperationCode.Callvirt;
        }

        private static IEnumerable<ITypeReference> CalleeTypes(this IOperation o)
        {
            yield return (o.Value as ITypeMemberReference).ContainingType;
        }
    }
}
