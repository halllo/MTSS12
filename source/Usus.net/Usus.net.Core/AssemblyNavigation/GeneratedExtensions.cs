using System.Collections.Generic;
using System.Linq;
using Microsoft.Cci;

namespace andrena.Usus.net.Core.AssemblyNavigation
{
    internal static class GeneratedExtensions
    {
        public static IEnumerable<INamedTypeDefinition> GetTypes(this IAssembly assembly)
        {
            return from t in assembly.GetAllTypes()
                   select t;
        }

        public static bool HasAnyGeneratedCodeAttributes(this IReference r)
        {
            return r.Attributes.Any((a => a.IsGeneratedCodeAttribute()));
        }

        private static bool IsGeneratedCodeAttribute(this ICustomAttribute a)
        {
            return a.Type.ToString().Contains("CompilerGeneratedAttribute");
        }

        public static IEnumerable<IMethodDefinition> GetMethods(this INamedTypeDefinition type)
        {
            return from t in type.Methods
                   select t;
        }
    }
}
