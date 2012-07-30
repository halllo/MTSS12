using System.Collections.ObjectModel;
using andrena.Usus.net.Core.Helper;
using andrena.Usus.net.View.Hub;
using System;

namespace andrena.Usus.net.View.ViewModels.Cockpit
{
    public class Cockpit : AnalysisAwareViewModel
    {
        CockpitEntry _AverageComponentDependency;
        CockpitEntry _ClassSize;
        CockpitEntry _CyclomaticComplexity;
        CockpitEntry _MethodLength;
        CockpitEntry _NonStaticPublicFields;
        CockpitEntry _NamespacesWithCycles;

        public ObservableCollection<CockpitEntry> Entries { get; private set; }
        public string Rloc { get; private set; }
        public string LastMetricsTime { get; private set; }

        public Cockpit()
        {
            Entries = new ObservableCollection<CockpitEntry>();
            Entries.Add(_AverageComponentDependency = new CockpitEntry { Metric = "Average Component Dependency" });
            Entries.Add(_ClassSize = new CockpitEntry { Metric = "Class Size" });
            Entries.Add(_CyclomaticComplexity = new CockpitEntry { Metric = "Cyclomatic Complexity" });
            Entries.Add(_MethodLength = new CockpitEntry { Metric = "Method Length" });
            Entries.Add(_NonStaticPublicFields = new CockpitEntry { Metric = "Non-Static Public Fields" });
            Entries.Add(_NamespacesWithCycles = new CockpitEntry { Metric = "Namespaces with Cycles" });

        }

        protected override void AnalysisStarted()
        { }

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
            _AverageComponentDependency.Average = metrics.Rated.AverageComponentDependency.Percent();
            _AverageComponentDependency.Total = AllClasses(metrics);
            _AverageComponentDependency.Hotspots = metrics.CumulativeComponentDependencyHotspots.Number();
            _AverageComponentDependency.Distribution = metrics.CumulativeComponentDependencyHistogram.GeometricalFit.Parameter.Value();
        }

        private void SetClassSize(PreparedMetricsReport metrics)
        {
            _ClassSize.Average = metrics.Rated.AverageRatedClassSize.Percent();
            _ClassSize.Total = AllClasses(metrics);
            _ClassSize.Hotspots = metrics.ClassSizeHotspots.Number();
            _ClassSize.Distribution = metrics.ClassSizeHistogram.GeometricalFit.Parameter.Value();
        }

        private void SetCyclomaticComplexity(PreparedMetricsReport metrics)
        {
            _CyclomaticComplexity.Average = metrics.Rated.AverageRatedCyclomaticComplexity.Percent();
            _CyclomaticComplexity.Total = AllMethods(metrics);
            _CyclomaticComplexity.Hotspots = metrics.CyclomaticComplexityHotspots.Number();
            _CyclomaticComplexity.Distribution = metrics.CyclomaticComplexityHistogram.GeometricalFit.Parameter.Value();
        }

        private void SetMethodLength(PreparedMetricsReport metrics)
        {
            _MethodLength.Average = metrics.Rated.AverageRatedMethodLength.Percent();
            _MethodLength.Total = AllMethods(metrics);
            _MethodLength.Hotspots = metrics.MethodLengthHotspots.Number();
            _MethodLength.Distribution = metrics.MethodLengthHistogram.GeometricalFit.Parameter.Value();
        }

        private void SetNumberOfNonStaticPublicFields(PreparedMetricsReport metrics)
        {
            _NonStaticPublicFields.Average = metrics.Rated.AverageRatedNumberOfNonStaticPublicFields.Percent();
            _NonStaticPublicFields.Total = AllClasses(metrics);
            _NonStaticPublicFields.Hotspots = metrics.NumberOfNonStaticPublicFieldsHotspots.Number();
            _NonStaticPublicFields.Distribution = metrics.NumberOfNonStaticPublicFieldsHistogram.GeometricalFit.Parameter.Value();
        }

        private void SetNamespacesWithCycles(PreparedMetricsReport metrics)
        {
            _NamespacesWithCycles.Average = metrics.Rated.NamespacesWithCyclicDependencies.Percent();
            _NamespacesWithCycles.Total = AllNamespaces(metrics);
            _NamespacesWithCycles.Hotspots = metrics.NumberOfNamespacesInCycleHotspots.Number();
            _NamespacesWithCycles.Distribution = metrics.NumberOfNamespacesInCycleHistogram.GeometricalFit.Parameter.Value();
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
