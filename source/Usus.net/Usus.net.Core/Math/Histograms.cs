using System;
using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.Core.Math
{
    public static class Histograms
    {

        public static IHistogram TypeHistogram(this MetricsReport metrics, Func<TypeMetricsReport, int> selector)
        {
            return new Histogram(metrics.TypesNotGenerated(selector));
        }

        public static IHistogram MethodHistogram(this MetricsReport metrics, Func<MethodMetricsReport, int> selector)
        {
            return new Histogram(metrics.MethodsNotGenerated(selector));
        }

        public static IHistogram NamespaceHistogram(this MetricsReport metrics, Func<NamespaceMetricsReport, int> selector)
        {
            return new Histogram(metrics.Namespaces.Select(selector));
        }

        private static IEnumerable<T> TypesNotGenerated<T>(this MetricsReport metrics, Func<TypeMetricsReport, T> selector)
        {
            return from t in metrics.Types
                   where !t.CompilerGenerated
                   select selector(t);
        }

        private static IEnumerable<T> MethodsNotGenerated<T>(this MetricsReport metrics, Func<MethodMetricsReport, T> selector)
        {
            return from m in metrics.Methods
                   where !m.CompilerGenerated
                   where !m.OnlyDeclaration
                   where m.CyclomaticComplexity > 0
                   where m.MethodLength > 0
                   select selector(m);
        }
    }
}
