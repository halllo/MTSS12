using System.Linq;
using Microsoft.Cci;

namespace andrena.Usus.net.Core.Metrics.Types
{
    internal static class NumberOfNonStaticPublicFields
    {
        public static int Of(INamedTypeDefinition type)
        {
            return type.Fields.Count(f => !f.IsStatic && f.Visibility == TypeMemberVisibility.Public);
        }
    }
}
