using System;
using System.Linq.Expressions;
using System.Reflection;

namespace andrena.Usus.net.Core.ReflectionHelper
{
    public static class MethodExtensions
    {
        public static string GetCalleeName(this MethodCallExpression methodCall)
        {
            return methodCall != null ? methodCall.Method.GetFullName() : null;
        }

        public static string GetFullName(this MethodInfo method)
        {
            return String.Format("{0} {1}.{2}",
                method.FullReturnTypeName(),
                method.FullDeclaringType(),
                method.MethodNameAndParameters());
        }
  
        private static string FullDeclaringType(this MethodInfo method)
        {
            return NormalizeSubTypeName(method.DeclaringType.FullName);
        }

        private static string FullReturnTypeName(this MethodInfo method)
        {
            if (method.ReturnType.IsGenericType)
                return NormalizeGenericName(method.ReturnParameter.ToString());
            else
                return method.ReturnType.FullName;
        }

        private static string MethodNameAndParameters(this MethodInfo method)
        {
            return NormalizeWhiteSpaces(
                NormalizeByRefs(
                NormalizeGenericName(
                NormalizePropertyName(
                method.JustName()))));
        }
  
        private static string JustName(this MethodInfo method)
        {
            return method.ToString().StartingAfterFirst(" ");
        }
  
        private static string NormalizePropertyName(string methodName)
        {
            return methodName
                .ReplaceIfStartsWith("get_", "()", ".get()")
                .ReplaceIfStartsWith("set_", "(", ".set(");
        }

        private static string NormalizeGenericName(string methodName)
        {
            return methodName.ReplaceRegex("`.*?\\[", "[").Replace("[", "<").Replace("]", ">").Trim();
        }

        private static string NormalizeByRefs(string methodName)
        {
            return methodName.Replace(" ByRef,", ",").Replace(" ByRef)", ")");
        }

        private static string NormalizeWhiteSpaces(string methodName)
        {
            return methodName.Replace(", ", ",");
        }

        private static string NormalizeSubTypeName(string subTypeName)
        {
            return subTypeName.Replace("+", ".");
        }
    }
}
