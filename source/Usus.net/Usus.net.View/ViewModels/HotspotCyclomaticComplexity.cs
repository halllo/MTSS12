using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.View.ViewModels
{
    public class HotspotCyclomaticComplexity : IDoubleClickable
    {
        MethodMetricsReport Metrics;
        
        public int Complexity { get { return Metrics.CyclomaticComplexity;} }
        public string Method { get { return Metrics.Name;} }
        public string Signature { get { return Metrics.Signature;} }
        
        public HotspotCyclomaticComplexity(MethodMetricsReport metrics)
        {
            Metrics = metrics;
        }

        public void OnDoubleClick()
        {
            System.Windows.MessageBox.Show(Metrics.ToString());
        }
    }
}
