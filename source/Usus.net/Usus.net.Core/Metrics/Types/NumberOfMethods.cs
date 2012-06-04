using System.Linq;
using Microsoft.Cci;

namespace andrena.Usus.net.Core.Metrics.Types
{
    internal static class NumberOfMethods
    {
        public static int Of(INamedTypeDefinition type)
        {
            return type.Methods.Count();
        }
    }
}
