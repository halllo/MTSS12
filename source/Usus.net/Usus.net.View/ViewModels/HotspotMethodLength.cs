using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.View.ViewModels
{
    public class HotspotMethodLength : IDoubleClickable
    {
        MethodMetricsReport Metrics;

        public int Length { get { return Metrics.MethodLength; } }
        public string Method { get { return Metrics.Name; } }
        public string Signature { get { return Metrics.Signature; } }

        public HotspotMethodLength(MethodMetricsReport metrics)
        {
            Metrics = metrics;
        }

        public void OnDoubleClick()
        {
            System.Windows.MessageBox.Show(Metrics.ToString());
        }
    }
}
