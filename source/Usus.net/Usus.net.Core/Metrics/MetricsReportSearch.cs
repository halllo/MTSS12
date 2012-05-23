using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using andrena.Usus.net.Core.ReflectionHelper;

namespace andrena.Usus.net.Core.Metrics
{
    public static class MetricsReportSearch
    {
        public static MethodMetricsReport For(this MetricsReport metrics, Expression<Action> method)
        {
            var methodName = (method.Body as MethodCallExpression).GetCalleeName();
            return metrics.For(methodName);
        }

        public static MethodMetricsReport For(this MetricsReport metrics, MethodInfo method)
        {
            return metrics.For(method.GetFullName());
        }

        public static MethodMetricsReport For(this MetricsReport metrics, string methodName)
        {
            return (from m in metrics.Methods
                    where m.Signature == methodName
                    select m).FirstOrDefault();
        }
    }
}
