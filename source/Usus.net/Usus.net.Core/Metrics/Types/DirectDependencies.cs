using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.AssemblyNavigation;
using andrena.Usus.net.Core.Reports;
using Microsoft.Cci;

namespace andrena.Usus.net.Core.Metrics.Types
{
    internal static class DirectDependencies
    {
        public static IEnumerable<string> Of(INamedTypeDefinition type, IEnumerable<MethodMetricsReport> methods)
        {
            var typesOfMethods = GetMethodTypes(methods).ToList();
            var typesOfFields = GetFieldTypes(type.Fields).ToList();
            var typesOfAncestors = GetAncestorTypes(type).ToList();

            return Enumerable.Empty<string>()
                .Union(typesOfMethods)
                .Union(typesOfFields)
                .Union(typesOfAncestors)
                .ToList();
        }

        private static IEnumerable<string> GetMethodTypes(IEnumerable<MethodMetricsReport> methods)
        {
            return from m in methods
                   from td in m.TypeDependencies
                   select td;
        }

        private static IEnumerable<string> GetFieldTypes(IEnumerable<IFieldDefinition> fields)
        {
            return from f in fields
                   from t in f.Type.GetAllRealTypeReferences()
                   select t.ToString();
        }

        private static IEnumerable<string> GetAncestorTypes(INamedTypeDefinition type)
        {
            return from c in type.BaseClasses.Concat(type.Interfaces)
                   from t in c.GetAllRealTypeReferences()
                   select t.ToString();
        }
    }
}
