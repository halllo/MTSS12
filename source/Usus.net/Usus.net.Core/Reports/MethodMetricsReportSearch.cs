using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using andrena.Usus.net.Core.ReflectionHelper;

namespace andrena.Usus.net.Core.Reports
{
    public static class MethodMetricsReportSearch
    {
        public static MethodMetricsReport ForMethod(this MetricsReport metrics, Expression<Action> expression)
        {
            var methodName = (expression.Body as MethodCallExpression).GetCalleeName();
            return metrics.ForMember(methodName);
        }

        public static MethodMetricsReport ForMethod(this MetricsReport metrics, MethodInfo method)
        {
            return metrics.ForMember(method.GetFullName());
        }

        public static MethodMetricsReport ForMember(this MetricsReport metrics, string memberName)
        {
            return (from m in metrics.Methods
                    where m.Signature == memberName
                    select m).FirstOrDefault();
        }
    }
}
