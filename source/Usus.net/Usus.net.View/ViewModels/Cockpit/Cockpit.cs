using System.Collections.ObjectModel;
using andrena.Usus.net.Core.Helper;
using andrena.Usus.net.View.Hub;
using System;

namespace andrena.Usus.net.View.ViewModels.Cockpit
{
    public class Cockpit : AnalysisAwareViewModel
    {
        public ObservableCollection<CockpitEntry> Entries { get; private set; }
        public string Rloc { get; private set; }
        public string LastMetricsTime { get; private set; }

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
                SetFooter(metrics);
            });
        }

        private void SetFooter(PreparedMetricsReport metrics)
        {
            Rloc = string.Format("{0} Relevant Lines Of Code", metrics.CommonKnowledge.RelevantLinesOfCode);
            Changed(() => Rloc);
            LastMetricsTime = string.Format("  ({0})", DateTime.Now.ToShortTimeString());
            Changed(() => LastMetricsTime);
        }

        private void SetACD(PreparedMetricsReport metrics)
        {
            Entries.Add(new CockpitEntry
                        {
                            Metric = "Average Component Dependency",
                            Average = metrics.Rated.AverageComponentDependency.Percent(),
                            Total = AllClasses(metrics),
                            Hotspots = metrics.CumulativeComponentDependencyHotspots.Number(),
                            Distribution = metrics.CumulativeComponentDependencyHistogram.GeometricalFit.Parameter.Value()
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
                            Distribution = metrics.ClassSizeHistogram.GeometricalFit.Parameter.Value()
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
                            Distribution = metrics.CyclomaticComplexityHistogram.GeometricalFit.Parameter.Value()
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
                            Distribution = metrics.MethodLengthHistogram.GeometricalFit.Parameter.Value()
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
                            Distribution = metrics.NumberOfNonStaticPublicFieldsHistogram.GeometricalFit.Parameter.Value()
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
                            Distribution = metrics.NumberOfNamespacesInCycleHistogram.GeometricalFit.Parameter.Value()
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
