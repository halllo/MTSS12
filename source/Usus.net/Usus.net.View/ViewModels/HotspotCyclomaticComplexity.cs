using andrena.Usus.net.Core.Reports;
using andrena.Usus.net.View.ExtensionPoints;

namespace andrena.Usus.net.View.ViewModels
{
    public class HotspotCyclomaticComplexity : IDoubleClickable<IJumpToSource>
    {
        MethodMetricsReport Metrics;
        
        public int Complexity { get { return Metrics.CyclomaticComplexity;} }
        public string Method { get { return Metrics.Name;} }
        public string Signature { get { return Metrics.Signature;} }
        
        public HotspotCyclomaticComplexity(MethodMetricsReport metrics)
        {
            Metrics = metrics;
        }

        public void OnDoubleClick(IJumpToSource jumper)
        {
            if (Metrics.SourceLocation.IsAvailable)
                jumper.JumpToFileLocation(
                    Metrics.SourceLocation.Filename,
                    Metrics.SourceLocation.Line, true);
        }
    }
}
