using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Cci;

namespace andrena.Usus.net.Core.AssemblyNavigation
{
    public static class TypeExtensions
    {
        public static IEnumerable<ITypeReference> GetAllRealTypeReferences(this ITypeReference typeReference)
        {
            //Needs adjustment for recursive generics? Recursive call?
            if (typeReference is IGenericTypeInstanceReference)
                return AnalyzeGenericTypeReference(typeReference as IGenericTypeInstanceReference);
            else
                return AnalyzeNonGenericTypeReference(typeReference);
        }

        private static IEnumerable<ITypeReference> AnalyzeNonGenericTypeReference(ITypeReference typeReference)
        {
            yield return typeReference;
        }

        private static IEnumerable<ITypeReference> AnalyzeGenericTypeReference(IGenericTypeInstanceReference typeReference)
        {
            yield return typeReference.GenericType;
            foreach (var genericArg in typeReference.GenericArguments)
            {
                yield return genericArg;
            }
        }
    }
}
