using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.View.ViewModels
{
    public class HotspotNonStaticPublicFields : IDoubleClickable
    {
        TypeMetricsReport Metrics;

        public int Count { get { return Metrics.NumberOfNonStaticPublicFields; } }
        public string Class { get { return Metrics.Name; } }
        public string Fullname { get { return Metrics.FullName; } }

        public HotspotNonStaticPublicFields(TypeMetricsReport metrics)
        {
            Metrics = metrics;
        }

        public void OnDoubleClick()
        {
            System.Windows.MessageBox.Show(Metrics.ToString());
        }
    }
}
