using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.Statistics;

namespace andrena.Usus.net.Core.Reports
{
    public static class Distributions
    {
        private static Histogram NewHistogram(IEnumerable<int> data)
        {
            var maxValue = data.Max();
            var histogram = new Histogram();
            for (int i = 0; i <= maxValue; i++) histogram.AddBucket(new Bucket(-0.5 + i, 0.5 + i));
            histogram.AddData(data.Select(d => d * 1.0));
            return histogram;
        }

        public static Histogram TypeDistribution(this MetricsReport metrics, Func<TypeMetricsReport, int> selector)
        {
            return NewHistogram(metrics.TypesNotGenerated(selector));
        }

        public static Histogram MethodDistribution(this MetricsReport metrics, Func<MethodMetricsReport, int> selector)
        {
            return NewHistogram(metrics.MethodsNotGenerated(selector));
        }

        public static Histogram NamespaceDistribution(this MetricsReport metrics, Func<NamespaceMetricsReport, int> selector)
        {
            return NewHistogram(metrics.Namespaces.Select(selector));
        }

        private static IEnumerable<T> TypesNotGenerated<T>(this MetricsReport metrics, Func<TypeMetricsReport, T> selector)
        {
            return from t in metrics.Types
                   where !t.CompilerGenerated
                   select selector(t);
        }

        private static IEnumerable<T> MethodsNotGenerated<T>(this MetricsReport metrics, Func<MethodMetricsReport, T> selector)
        {
            return from t in metrics.Methods
                   where !t.CompilerGenerated
                   select selector(t);
        }
    }
}
