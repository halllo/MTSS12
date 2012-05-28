using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Cci;

namespace andrena.Usus.net.Core.AssemblyNavigation
{
    internal static class MethodExtensions
    {
        public static string Signature(this IMethodDefinition method)
        {
            return method.ToString().Replace(", ", ",");
        }

        public static string Name(this IMethodDefinition method)
        {
            return method.Name.ToString();
        }

        public static IEnumerable<IOperation> Operations(this IMethodDefinition method,
            Func<OperationCode, bool> predicate)
        {
            return from o in method.Body.Operations
                   where predicate(o.OperationCode)
                   select o;
        }
    }
}
