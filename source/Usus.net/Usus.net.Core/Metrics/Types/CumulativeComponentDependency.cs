using System.Linq;
using andrena.Usus.net.Core.Graphs;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.Core.Metrics.Types
{
    internal static class CumulativeComponentDependency
    {
        public static int Of(TypeMetricsReport type, Graph<string> graph)
        {
            return graph.Reach(type.FullName).Vertices.Count();
        }
    }
}
