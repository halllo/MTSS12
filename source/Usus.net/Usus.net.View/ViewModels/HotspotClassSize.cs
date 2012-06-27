using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.View.ViewModels
{
    public class HotspotClassSize : IDoubleClickable
    {
        TypeMetricsReport Metrics;

        public int Size { get { return Metrics.ClassSize; } }
        public string Class { get { return Metrics.Name; } }
        public string Fullname { get { return Metrics.FullName; } }

        public HotspotClassSize(TypeMetricsReport metrics)
        {
            Metrics = metrics;
        }

        public void OnDoubleClick()
        {
            System.Windows.MessageBox.Show(Metrics.ToString());
        }
    }
}
