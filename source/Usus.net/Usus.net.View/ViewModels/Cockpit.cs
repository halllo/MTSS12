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
            Entries.Add(new CockpitEntry { Metric = "Average Component Dependency", Average = ratedMetrics.AverageComponentDependency.Percent(), Total = AllClasses(ratedMetrics) });
            Entries.Add(new CockpitEntry { Metric = "Class Size", Average = ratedMetrics.AverageRatedClassSize.Percent(), Total = AllClasses(ratedMetrics) });
            Entries.Add(new CockpitEntry { Metric = "Cyclomatic Complexity", Average = ratedMetrics.AverageRatedCyclomaticComplexity.Percent(), Total = AllMethods(ratedMetrics) });
            Entries.Add(new CockpitEntry { Metric = "Method Length", Average = ratedMetrics.AverageRatedMethodLength.Percent(), Total = AllMethods(ratedMetrics) });
            Entries.Add(new CockpitEntry { Metric = "Number Of Non-Static Public Fields", Average = ratedMetrics.AverageRatedNumberOfNonStaticPublicFields.Percent(), Total = AllClasses(ratedMetrics) });
            Entries.Add(new CockpitEntry { Metric = "Namespaces with Cycles", Average = ratedMetrics.NamespacesWithCyclicDependencies.Percent(), Total = AllNamespaces(ratedMetrics) });
        }

        private string AllMethods(RatedMetrics ratedMetrics)
        {
            return ratedMetrics.Metrics.CommonKnowledge.NumberOfMethods + " methods";
        }
        
        private string AllClasses(RatedMetrics ratedMetrics)
        {
            return ratedMetrics.Metrics.CommonKnowledge.NumberOfClasses + " classes";
        }
        
        private string AllNamespaces(RatedMetrics ratedMetrics)
        {
            return ratedMetrics.Metrics.CommonKnowledge.NumberOfNamespaces + " namespaces";
        }
    }
}
