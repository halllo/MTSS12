using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using andrena.Usus.net.Core.Metrics;
using System.Reflection;

namespace andrena.Usus.net.Core
{
    public static class MetricsSearch
    {
        public static MethodMetricsReport For(this MetricsReport metrics, Expression<Action> method)
        {
            var methodName = GetFullName(method.Body as MethodCallExpression);
            return (from m in metrics.Methods
                    where m.Signature == methodName
                    select m).FirstOrDefault();
        }

        private static string GetFullName(MethodCallExpression methodCall)
        {
            if (methodCall != null)
            {
                return String.Format("{0} {1}.{2}", 
                    methodCall.Method.ReturnType.FullName, 
                    methodCall.Method.DeclaringType.FullName,
                    methodCall.Method.ToString().Substring(
                        methodCall.Method.ReturnType.Name.Length + 1));
            }
            return "";
        }
    }
}
