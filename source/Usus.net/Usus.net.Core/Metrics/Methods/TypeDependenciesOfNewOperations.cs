using System.Collections.Generic;
using Microsoft.Cci;

namespace andrena.Usus.net.Core.Metrics.Methods
{
    internal static class TypeDependenciesOfNewOperations
    {
        public static IEnumerable<string> Of(IMethodDefinition method)
        {
            return method.OperationTypes(
                o => o == OperationCode.Newobj, 
                o => o.NeweeTypes());
        }

        private static IEnumerable<ITypeReference> NeweeTypes(this IOperation o)
        {
            yield return (o.Value as ITypeMemberReference).ContainingType;
        }
    }
}
