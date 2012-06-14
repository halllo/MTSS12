using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.Core.Hotspots
{
    public class RatedNamespaceMetrics
    {
        public string Name { get; private set; }

        public int NumberOfNamespacesInCycle { get; private set; }

        public RatedNamespaceMetrics(NamespaceMetricsReport metrics)
        {
            Name = metrics.Name;
            NumberOfNamespacesInCycle = metrics.NumberOfNamespacesInCycle;
        }
    }
}
