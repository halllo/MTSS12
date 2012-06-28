using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.View.ViewModels.Hotspots
{
    public class HotspotNamespaceInCycle : Hotspot<NamespaceMetricsReport>
    {
        public int CycleSize { get { return Report.NumberOfNamespacesInCycle; } }
        public string Namespace { get { return Report.Name; } }

        public HotspotNamespaceInCycle(NamespaceMetricsReport namespaceReport)
            : base(namespaceReport)
        {
        }
    }
}
