using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.View.ViewModels
{
    public class HotspotCumulativeComponentDependency : IDoubleClickable
    {
        TypeMetricsReport Metrics;

        public int Dependencies { get { return Metrics.CumulativeComponentDependency; } }
        public string Class { get { return Metrics.Name; } }
        public string Fullname { get { return Metrics.FullName; } }

        public HotspotCumulativeComponentDependency(TypeMetricsReport metrics)
        {
            Metrics = metrics;
        }

        public void OnDoubleClick()
        {
            System.Windows.MessageBox.Show(Metrics.ToString());
        }
    }
}
