using Microsoft.Cci;

namespace andrena.Usus.net.Core.AssemblyNavigation
{
    internal static class TypeExtensions
    {
        public static string Name(this INamedTypeDefinition type)
        {
            return type.Name.ToString();
        }
    }
}
