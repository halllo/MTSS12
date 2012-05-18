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
            return GetGenericType(typeReference)
                .Union(GetGenericTypeArguments(typeReference));
        }

        private static IEnumerable<ITypeReference> GetGenericType(IGenericTypeInstanceReference typeReference)
        {
            yield return typeReference.GenericType;
        }

        private static IEnumerable<ITypeReference> GetGenericTypeArguments(IGenericTypeInstanceReference typeReference)
        {
            return from a in typeReference.GenericArguments
                   from t in a.GetAllRealTypeReferences()
                   select t;
        }
    }
}
