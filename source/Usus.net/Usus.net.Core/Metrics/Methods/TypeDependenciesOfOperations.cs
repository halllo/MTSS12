using System;
using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.AssemblyNavigation;
using Microsoft.Cci;

namespace andrena.Usus.net.Core.Metrics.Methods
{
    internal static class TypeDependenciesOfOperations
    {
        public static IEnumerable<string> OperationTypes(this IMethodDefinition method,
            Func<OperationCode, bool> predicate,
            Func<IOperation, IEnumerable<ITypeReference>> selector)
        {
            return from o in method.Operations(predicate)
                   from t in selector(o)
                   from rt in t.GetAllRealTypeReferences()
                   select rt.ToString();
        }
    }
}
