using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.View.ViewModels
{
    public class HotspotNamespaceInCycle : IDoubleClickable
    {
        NamespaceMetricsReport Metrics;

        public int CycleSize { get { return Metrics.NumberOfNamespacesInCycle; } }
        public string Namespace { get { return Metrics.Name; } }

        public HotspotNamespaceInCycle(NamespaceMetricsReport metrics)
        {
            Metrics = metrics;
        }

        public void OnDoubleClick()
        {
            System.Windows.MessageBox.Show(Metrics.ToString());
        }
    }
}
