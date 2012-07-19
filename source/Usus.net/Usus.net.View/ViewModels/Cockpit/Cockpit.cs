using System.Collections.ObjectModel;
using andrena.Usus.net.Core.Helper;
using andrena.Usus.net.View.Hub;

namespace andrena.Usus.net.View.ViewModels.Cockpit
{
    public class Cockpit : AnalysisAwareViewModel
    {
        public ObservableCollection<CockpitEntry> Entries { get; private set; }
        public string Rloc { get; private set; }

        public Cockpit()
        {
            Entries = new ObservableCollection<CockpitEntry>();
        }

        protected override void AnalysisStarted()
        {
            Entries.Clear();
        }

        protected override void AnalysisFinished(PreparedMetricsReport metrics)
        {
            Dispatch(() =>
            {
                SetACD(metrics);
                SetClassSize(metrics);
                SetCyclomaticComplexity(metrics);
                SetMethodLength(metrics);
                SetNumberOfNonStaticPublicFields(metrics);
                SetNamespacesWithCycles(metrics);
                SetRloc(metrics);
            });
        }

        private void SetRloc(PreparedMetricsReport metrics)
        {
            Rloc = string.Format("{0} Relevant Lines Of Code", metrics.CommonKnowledge.RelevantLinesOfCode);
            Changed(() => Rloc);
        }

        private void SetACD(PreparedMetricsReport metrics)
        {
            Entries.Add(new CockpitEntry
                        {
                            Metric = "Average Component Dependency",
                            Average = metrics.Rated.AverageComponentDependency.Percent(),
                            Total = AllClasses(metrics),
                            Hotspots = metrics.CumulativeComponentDependencyHotspots.Number(),
                            Distribution = metrics.CumulativeComponentDependencyHistogram.Fitting.ForGeometricalDistribution.Value()
                        });
        }

        private void SetClassSize(PreparedMetricsReport metrics)
        {
            Entries.Add(new CockpitEntry
                        {
                            Metric = "Class Size",
                            Average = metrics.Rated.AverageRatedClassSize.Percent(),
                            Total = AllClasses(metrics),
                            Hotspots = metrics.ClassSizeHotspots.Number(),
                            Distribution = metrics.ClassSizeHistogram.Fitting.ForGeometricalDistribution.Value()
                        });
        }

        private void SetCyclomaticComplexity(PreparedMetricsReport metrics)
        {
            Entries.Add(new CockpitEntry
                        {
                            Metric = "Cyclomatic Complexity",
                            Average = metrics.Rated.AverageRatedCyclomaticComplexity.Percent(),
                            Total = AllMethods(metrics),
                            Hotspots = metrics.CyclomaticComplexityHotspots.Number(),
                            Distribution = metrics.CyclomaticComplexityHistogram.Fitting.ForGeometricalDistribution.Value()
                        });
        }

        private void SetMethodLength(PreparedMetricsReport metrics)
        {
            Entries.Add(new CockpitEntry
                        {
                            Metric = "Method Length",
                            Average = metrics.Rated.AverageRatedMethodLength.Percent(),
                            Total = AllMethods(metrics),
                            Hotspots = metrics.MethodLengthHotspots.Number(),
                            Distribution = metrics.MethodLengthHistogram.Fitting.ForGeometricalDistribution.Value()
                        });
        }

        private void SetNumberOfNonStaticPublicFields(PreparedMetricsReport metrics)
        {
            Entries.Add(new CockpitEntry
                        {
                            Metric = "Non-Static Public Fields",
                            Average = metrics.Rated.AverageRatedNumberOfNonStaticPublicFields.Percent(),
                            Total = AllClasses(metrics),
                            Hotspots = metrics.NumberOfNonStaticPublicFieldsHotspots.Number(),
                            Distribution = metrics.NumberOfNonStaticPublicFieldsHistogram.Fitting.ForGeometricalDistribution.Value()
                        });
        }

        private void SetNamespacesWithCycles(PreparedMetricsReport metrics)
        {
            Entries.Add(new CockpitEntry
                        {
                            Metric = "Namespaces with Cycles",
                            Average = metrics.Rated.NamespacesWithCyclicDependencies.Percent(),
                            Total = AllNamespaces(metrics),
                            Hotspots = metrics.NumberOfNamespacesInCycleHotspots.Number(),
                            Distribution = metrics.NumberOfNamespacesInCycleHistogram.Fitting.ForGeometricalDistribution.Value()
                        });
        }

        private string AllMethods(PreparedMetricsReport metrics)
        {
            return metrics.Report.CommonKnowledge.NumberOfMethods + " methods";
        }

        private string AllClasses(PreparedMetricsReport metrics)
        {
            return metrics.Report.CommonKnowledge.NumberOfClasses + " classes";
        }

        private string AllNamespaces(PreparedMetricsReport metrics)
        {
            return metrics.Report.CommonKnowledge.NumberOfNamespaces + " namespaces";
        }
    }
}
