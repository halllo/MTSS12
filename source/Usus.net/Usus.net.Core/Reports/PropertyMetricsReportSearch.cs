using System;
using System.Linq.Expressions;
using System.Reflection;
using andrena.Usus.net.Core.ReflectionHelper;

namespace andrena.Usus.net.Core.Reports
{
    public static class PropertyMetricsReportSearch
    {
        public static PropertyMetricsReport ForProperty(this MetricsReport metrics, Expression<Func<object>> expression)
        {
            return metrics.ForProperty(PropertyExtensions.GetPropertyInfo(expression));
        }

        public static PropertyMetricsReport ForProperty(this MetricsReport metrics, PropertyInfo property)
        {
            return new PropertyMetricsReport
            {
                Getter = metrics.ForMember(property.GetFullGetterName()),
                Setter = metrics.ForMember(property.GetFullSetterName())
            };
        }
    }
}
