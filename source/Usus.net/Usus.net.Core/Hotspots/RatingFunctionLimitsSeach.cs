using System;
using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.Core.Hotspots
{
    internal static class RatingFunctionLimitsSeach
    {
        public static IEnumerable<MethodMetricsReport> MethodsOverLimit<T>(this MetricsReport metrics, Func<MethodMetricsReport, T> metricSelector, Func<RatingFunctionLimits, Func<CommonReportKnowledge, T>> limitSelector)
            where T : IComparable<T>
        {
            return from method in metrics.Methods
                   where metricSelector(method).CompareTo(limitSelector(RatingFunctions.Limits)(metrics.CommonKnowledge)) > 0
                   select method;
        }

        public static IEnumerable<TypeMetricsReport> TypesOverLimit<T>(this MetricsReport metrics, Func<TypeMetricsReport, T> metricSelector, Func<RatingFunctionLimits, Func<CommonReportKnowledge, T>> limitSelector)
            where T : IComparable<T>
        {
            return from type in metrics.Types
                   where metricSelector(type).CompareTo(limitSelector(RatingFunctions.Limits)(metrics.CommonKnowledge)) > 0
                   select type;
        }
    }
}
