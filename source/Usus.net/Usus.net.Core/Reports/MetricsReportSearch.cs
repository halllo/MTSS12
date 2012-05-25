using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using andrena.Usus.net.Core.ReflectionHelper;

namespace andrena.Usus.net.Core.Reports
{
    public static partial class MetricsReportSearch
    {
        public static MethodMetricsReport For(this MetricsReport metrics, Expression<Action> expression)
        {
            var methodName = (expression.Body as MethodCallExpression).GetCalleeName();
            return metrics.For(methodName);
        }

        public static MethodMetricsReport For<T>(this MetricsReport metrics, Expression<Func<T>> expression)
        {
            var methodName = (expression.Body as MemberExpression).GetCalleeName();
            return metrics.For(methodName);
        }

        public static MethodMetricsReport For(this MetricsReport metrics, MethodInfo method)
        {
            return metrics.For(method.GetFullName());
        }

        public static PropertyMetricsReport For(this MetricsReport metrics, PropertyInfo property)
        {
            return new PropertyMetricsReport
            {
                Getter = metrics.For(property.GetFullGetterName()),
                Setter = metrics.For(property.GetFullSetterName())
            };
        }

        public static MethodMetricsReport For(this MetricsReport metrics, string methodName)
        {
            return (from m in metrics.Methods
                    where m.Signature == methodName
                    select m).FirstOrDefault();
        }
    }
}
