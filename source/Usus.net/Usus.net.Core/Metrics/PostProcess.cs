using andrena.Usus.net.Core.Metrics.Types;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.Core.Metrics
{
    internal static class PostProcess
    {
        public static MetricsReport Metrics(MetricsReport metrics)
        {
            metrics.SetInterestingDirectDependencies();
            
            //create graph

            metrics.SetCumulativeComponentDependency();
            return metrics;
        }

        private static void SetInterestingDirectDependencies(this MetricsReport metrics)
        {
            foreach (var type in metrics.Types)
                type.InterestingDirectDependencies = InterestingDirectDependencies.Of(type, metrics.Types);
        }

        private static void SetCumulativeComponentDependency(this MetricsReport metrics)
        {
            foreach (var type in metrics.Types)
                type.CumulativeComponentDependency = CumulativeComponentDependency.Of(type);
        }
    }
}
