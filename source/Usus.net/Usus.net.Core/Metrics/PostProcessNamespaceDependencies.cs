using andrena.Usus.net.Core.Metrics.Namespaces;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.Core.Metrics
{
    internal static class PostProcessNamespaceDependencies
    {
        public static void Of(MetricsReport metrics)
        {
            metrics.GraphOfNamespaces = CreateGraph.WithNamespacesOf(metrics);
            metrics.SetNamespacesWithCyclicDependencies();
        }

        private static void SetNamespacesWithCyclicDependencies(this MetricsReport metrics)
        {
            var cycles = CyclicDependencies.In(metrics.GraphOfNamespaces);
            foreach (var cycle in cycles)
            {
            }

        }
    }
}
