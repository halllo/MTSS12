using System.Collections.Generic;
using andrena.Usus.net.Core.Graphs;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.Core.Metrics.Namespaces
{
    internal static class CyclicDependencies
    {
        public static IEnumerable<IEnumerable<NamespaceMetricsWithTypeMetrics>> In(MutableGraph<NamespaceMetricsWithTypeMetrics> graph)
        {
            return graph.Cycles();
        }
    }
}
