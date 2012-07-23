using System.Collections.ObjectModel;
using System.Linq;
using andrena.Usus.net.Core.Helper;
using andrena.Usus.net.Core.SQI;
using andrena.Usus.net.View.Hub;

namespace andrena.Usus.net.View.ViewModels.SQI
{
    public class SQI : AnalysisAwareViewModel
    {
        public ObservableCollection<SqiParameter> Parameters { get; private set; }
        public string Sqi { get; private set; }
        SqiParameters sqiParameters;

        public SQI()
        {
            Parameters = new ObservableCollection<SqiParameter>();
            sqiParameters = new SqiParameters();
            sqiParameters.ParametersChanged += CalculateSqi;
            Sqi = 0.0.Percent();
        }

        protected override void AnalysisStarted()
        {
            Parameters.Clear();
        }

        protected override void AnalysisFinished(Hub.PreparedMetricsReport metrics)
        {
            SetCommonKnowledge(metrics);
            Dispatch(() =>
            {
                SetParameters(metrics);
                CalculateSqi();
            });
        }

        private void SetCommonKnowledge(PreparedMetricsReport metrics)
        {
            sqiParameters.Classes = metrics.CommonKnowledge.NumberOfClasses;
            sqiParameters.Methods = metrics.CommonKnowledge.NumberOfMethods;
            sqiParameters.Namespaces = metrics.CommonKnowledge.NumberOfNamespaces;
            sqiParameters.Rloc = metrics.CommonKnowledge.RelevantLinesOfCode;
        }

        private void SetParameters(PreparedMetricsReport metrics)
        {
            Parameters.Add(sqiParameters.Assign("Test Coverage", 0.0, (p, v) => p.TestCoverage = v));
            Parameters.Add(sqiParameters.Assign("Namespaces in Cycles", metrics.NumberOfNamespacesInCycleHotspots.Count(), (p, v) => p.NamespaceCycles = v));
            Parameters.Add(sqiParameters.Assign("Complicated Methods", metrics.Hotspots.OfCyclomaticComplexityOver(5).Count(), (p, v) => p.ComplicatedMethods = v));
            Parameters.Add(sqiParameters.Assign("Average Component Dependency", metrics.Rated.AverageComponentDependency * 100.0, (p, v) => p.AverageComponentDependency = v));
            Parameters.Add(sqiParameters.Assign("Big Classes", metrics.Hotspots.OfClassSizeOver(20).Count(), (p, v) => p.BigClasses = v));
            Parameters.Add(sqiParameters.Assign("Bis Methods", metrics.Hotspots.OfMethodLengthOver(15).Count(), (p, v) => p.BigMethods = v));
            Parameters.Add(sqiParameters.Assign("Compiler Warnings", 0, (p, v) => p.CompilerWarnings = v));
        }

        public void CalculateSqi()
        {
            Sqi = (sqiParameters.SoftwareQualityIndex() / 100.0).Percent();
            Dispatch(() => Changed(() => Sqi));
        }
    }
}
