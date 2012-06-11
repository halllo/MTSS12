using System.Linq;
using andrena.Usus.net.Core.Graphs;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.Core.Metrics
{
    internal static class PostProcessNamespaceDependencies
    {
        public static void Of(MetricsReport metrics)
        {
            metrics.NamespaceGraph = metrics.TypeGraph.ToNamespaceGraph();
        }

        private static Graph<NamespacedTypes> ToNamespaceGraph(this Graph<TypeMetricsReport> typeGraph)
        {
            var namespaceGraph = typeGraph.Cast(t => t.AsNamespacedTypes());
            var namespaceGroups = namespaceGraph.Vertices.GroupBy(n => n.Namespace);
            foreach (var namespaceGroup in namespaceGroups)
                namespaceGraph.Reduce(namespaceGroup.AsNamespacedTypes(), namespaceGroup);
            return namespaceGraph;
        }

        private static NamespacedTypes AsNamespacedTypes(this IGrouping<string, NamespacedTypes> namespaceGroup)
        {
            var namespacedTypes = new NamespacedTypes(namespaceGroup.Key);
            namespacedTypes.AddTypes(namespaceGroup);
            return namespacedTypes;
        }

        private static NamespacedTypes AsNamespacedTypes(this TypeMetricsReport t)
        {
            var namespacedTypes = new NamespacedTypes(t.Namespaces.First());
            namespacedTypes.AddType(t);
            return namespacedTypes;
        }
    }
}
