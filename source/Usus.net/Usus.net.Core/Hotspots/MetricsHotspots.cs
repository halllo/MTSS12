using System;
using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.Core.Hotspots
{
    public class MetricsHotspots
    {
        public MetricsReport Metrics { get; private set; }

        internal MetricsHotspots(MetricsReport metrics)
        {
            Metrics = metrics;
        }

        public IEnumerable<MethodMetricsReport> OfCyclomaticComplexity()
        {
            return MethodsWhereOverLimit(m => m.CyclomaticComplexity, l => l.CyclomaticComplexity);
        }

        public IEnumerable<MethodMetricsReport> OfMethodLength()
        {
            return MethodsWhereOverLimit(m => m.NumberOfLogicalLines, l => l.MethodLength);
        }

        private IEnumerable<MethodMetricsReport> MethodsWhereOverLimit<T>(Func<MethodMetricsReport, T> metricSelector, Func<RatingFunctionLimits, T> limitSelector)
            where T : IComparable<T>
        {
            return from method in Metrics.Methods
                   where metricSelector(method).CompareTo(limitSelector(RatingFunctions.Limits)) > 0
                   select method;
        }
    }
}
