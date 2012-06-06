using System.Linq;
using andrena.Usus.net.Core.Graphs;
using andrena.Usus.net.Core.Metrics.Types;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.Core.Metrics
{
    internal static class PostProcess
    {
        public static MetricsReport Metrics(MetricsReport metrics)
        {
            metrics.SetInterestingDirectDependencies();
            var graph = metrics.ToTypeGraph();
            metrics.SetCumulativeComponentDependency(graph);
            return metrics;
        }

        private static void SetInterestingDirectDependencies(this MetricsReport metrics)
        {
            foreach (var type in metrics.Types)
                type.InterestingDirectDependencies = InterestingDirectDependencies.Of(type, metrics.Types);
        }

        private static Graph<string> ToTypeGraph(this MetricsReport metrics)
        {
            return metrics.Types
                .ToDictionary(t => t.FullName, t => t.InterestingDirectDependencies)
                .ToGraph();
        }

        private static void SetCumulativeComponentDependency(this MetricsReport metrics, Graph<string> graph)
        {
            foreach (var type in metrics.Types)
                type.CumulativeComponentDependency = CumulativeComponentDependency.Of(type, graph);
        }
    }
}
