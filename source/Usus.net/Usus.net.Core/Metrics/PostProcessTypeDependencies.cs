using System.Linq;
using andrena.Usus.net.Core.Graphs;
using andrena.Usus.net.Core.Metrics.Types;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.Core.Metrics
{
    internal static class PostProcessTypeDependencies
    {
        public static void Of(MetricsReport metrics)
        {
            metrics.SetInterestingDirectDependencies();
            metrics.TypeGraph = metrics.ToTypeGraph();
            metrics.SetCumulativeComponentDependency();
        }

        private static void SetInterestingDirectDependencies(this MetricsReport metrics)
        {
            foreach (var type in metrics.Types)
                type.InterestingDirectDependencies = InterestingDirectDependencies.Of(type, metrics.Types);
        }

        private static Graph<TypeMetricsReport> ToTypeGraph(this MetricsReport metrics)
        {
            return metrics.Types
                .ToDictionary(t => t, t => t.InterestingDirectDependencies.Select(d => metrics.TypeForName(d)))
                .ToGraph();
        }

        private static void SetCumulativeComponentDependency(this MetricsReport metrics)
        {
            foreach (var type in metrics.Types)
                type.CumulativeComponentDependency = CumulativeComponentDependency.Of(type, metrics.TypeGraph);
        }
    }
}
