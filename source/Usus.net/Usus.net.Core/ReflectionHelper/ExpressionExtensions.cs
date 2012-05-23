using System;
using System.Linq.Expressions;
using System.Reflection;

namespace andrena.Usus.net.Core.ReflectionHelper
{
    public static class ExpressionExtensions
    {
        public static string GetCalleeName(this MethodCallExpression methodCall)
        {
            return methodCall != null ? methodCall.Method.GetFullName() : null;
        }

        public static string GetFullName(this MethodInfo method)
        {
            return String.Format("{0} {1}.{2}",
                GetFullReturnTypeName(method),
                GetFullDeclaringTpyeName(method),
                GetMethodNameAndParameters(method));
        }

        private static string GetFullReturnTypeName(MethodInfo method)
        {
            return method.ReturnType.FullName;
        }

        private static string GetFullDeclaringTpyeName(MethodInfo method)
        {
            return method.DeclaringType.FullName;
        }

        private static string GetMethodNameAndParameters(MethodInfo method)
        {
            int returnTypeStringLength = method.ReturnType.Name.Length + 1;
            return method.ToString().Substring(returnTypeStringLength);
        }
    }
}
