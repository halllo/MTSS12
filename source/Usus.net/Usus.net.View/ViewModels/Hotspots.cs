using andrena.Usus.net.Core.Hotspots;
using andrena.Usus.net.Core.Reports;
using andrena.Usus.net.View.ExtensionPoints;

namespace andrena.Usus.net.View.ViewModels
{
    public class Hotspots : HotspotsCollection
    {
        public IJumpToSource Jumper { private get; set; }

        public string CumulativeComponentDependenciesText { get; private set; }

        public Hotspots()
        {
        }

        protected override void AnalysisFinished(MetricsReport metrics)
        {
            base.AnalysisFinished(metrics);
            Dispatch(() => SetCumulativeComponentDependenciesText(metrics));
        }

        private void SetCumulativeComponentDependenciesText(MetricsReport metrics)
        {
            CumulativeComponentDependenciesText = string.Format("Classes with more than {0} cumulated dependencies.", RatingFunctions.Limits.CumulativeComponentDependency(metrics.CommonKnowledge));
            Changed(() => CumulativeComponentDependenciesText);
        }
    }
}
