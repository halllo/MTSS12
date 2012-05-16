using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Cci;

namespace andrena.Usus.net.Core
{
    public static class TypeExtensions
    {
        public static void Analyze(this INamedTypeDefinition type, PdbReader pdb)
        {
            //Console.WriteLine(type.ToString());
            foreach (var method in GetMethodsNotGenerated(type))
                method.Analyze(pdb);
            //Console.WriteLine();
        }

        public static IEnumerable<IMethodDefinition> GetMethodsNotGenerated(this INamedTypeDefinition type)
        {
            return from t in type.Methods
                   where !t.HasAnyGeneratedCodeAttributes()
                   select t;
        }
    }
}
