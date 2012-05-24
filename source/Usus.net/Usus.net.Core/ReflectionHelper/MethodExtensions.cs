using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;

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
                method.FullDeclaringTpyeName(),
                method.MethodNameAndParameters());
        }

        private static string FullReturnTypeName(this MethodInfo method)
        {
            if (method.ReturnType.IsGenericType)
                return GetAsGenerics(method.ReturnParameter.ToString());
            else
                return method.ReturnType.FullName;
        }

        private static string FullDeclaringTpyeName(this MethodInfo method)
        {
            return method.DeclaringType.FullName;
        }

        private static string MethodNameAndParameters(this MethodInfo method)
        {
            string methodName = method.StartingAfterFirst(" ");
            return GetAsGenerics(methodName);
        }

        private static string StartingAfterFirst(this MethodInfo method, string textToSkip)
        {
            int toSkip = method.ToString().IndexOf(" ") + 1;
            return method.ToString().Substring(toSkip);
        }

        private static string GetAsGenerics(string methodName)
        {
            var clearedAnonGenerics = Regex.Replace(methodName, "`.*?\\[", "[");
            return clearedAnonGenerics.Replace("[", "<").Replace("]", ">").Trim();
        }
    }
}
