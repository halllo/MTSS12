using System.Collections.ObjectModel;
using andrena.Usus.net.Core.Helper;
using andrena.Usus.net.Core.Hotspots;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.View.ViewModels
{
    public class Cockpit : AnalysisAwareViewModel
    {
        public ObservableCollection<CockpitEntry> Entries { get; private set; }

        public Cockpit()
        {
            Entries = new ObservableCollection<CockpitEntry>();
        }

        protected override void AnalysisStarted()
        {
            Entries.Clear();
        }

        protected override void AnalysisFinished(MetricsReport metrics)
        {
            var ratedMetrics = metrics.Rate();
            Dispatch(() => SetNewEntries(ratedMetrics));
        }

        private void SetNewEntries(RatedMetrics ratedMetrics)
        {
            Entries.Add(new CockpitEntry { Metric = "Average Component Dependency", Average = ratedMetrics.AverageComponentDependency.Percent() });
            Entries.Add(new CockpitEntry { Metric = "Class Size", Average = ratedMetrics.AverageRatedClassSize.Percent() });
            Entries.Add(new CockpitEntry { Metric = "Cyclomatic Complexity", Average = ratedMetrics.AverageRatedCyclomaticComplexity.Percent() });
            Entries.Add(new CockpitEntry { Metric = "Method Length", Average = ratedMetrics.AverageRatedMethodLength.Percent() });
            Entries.Add(new CockpitEntry { Metric = "Number Of Non-Static Public Fields", Average = ratedMetrics.AverageRatedNumberOfNonStaticPublicFields.Percent() });
            Entries.Add(new CockpitEntry { Metric = "Namespaces with Cycles", Average = ratedMetrics.NamespacesWithCyclicDependencies.Percent() });
        }
    }
}
