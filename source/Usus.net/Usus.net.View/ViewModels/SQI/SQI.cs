using System.Collections.ObjectModel;
using System.Linq;
using andrena.Usus.net.Core.Helper;
using andrena.Usus.net.View.ExtensionPoints;
using andrena.Usus.net.View.Hub;

namespace andrena.Usus.net.View.ViewModels.SQI
{
    public class SQI : AnalysisAwareViewModel
    {
        public ObservableCollection<SqiParameter> Parameters { get; private set; }
        public IKnowSqiDetails Details { get; set; }

        public string Sqi { get; private set; }
        SqiParameters sqiParameters;
        SqiParameter _TestCoverage;
        SqiParameter _NamespacesInCycles;
        SqiParameter _ComplicatedMethods;
        SqiParameter _AverageComponentDependency;
        SqiParameter _BigClasses;
        SqiParameter _BigMethods;
        SqiParameter _CompilerWarnings;

        public SQI()
        {
            Parameters = new ObservableCollection<SqiParameter>();
            SetupSqi();
            SetupSqiParameters();
        }

        private void SetupSqi()
        {
            sqiParameters = new SqiParameters();
            sqiParameters.SqiChanged += sqi =>
            {
                Sqi = (sqi / 100.0).Percent();
                Changed(() => Sqi);
            };
            Sqi = 0.0.Percent();
        }

        private void SetupSqiParameters()
        {
            Parameters.Add(_TestCoverage = sqiParameters.Assign("Test Coverage", 0.0, (p, v) => p.TestCoverage = v));
            Parameters.Add(_NamespacesInCycles = sqiParameters.Assign("Namespaces in Cycles", 0, (p, v) => p.NamespaceCycles = v));
            Parameters.Add(_ComplicatedMethods = sqiParameters.Assign("Complicated Methods", 0, (p, v) => p.ComplicatedMethods = v));
            Parameters.Add(_AverageComponentDependency = sqiParameters.Assign("Average Component Dependency", 0.0, (p, v) => p.AverageComponentDependency = v));
            Parameters.Add(_BigClasses = sqiParameters.Assign("Big Classes", 0, (p, v) => p.BigClasses = v));
            Parameters.Add(_BigMethods = sqiParameters.Assign("Bis Methods", 0, (p, v) => p.BigMethods = v));
            Parameters.Add(_CompilerWarnings = sqiParameters.Assign("Compiler Warnings", 0, (p, v) => p.CompilerWarnings = v));
        }

        protected override void AnalysisStarted()
        {
        }

        protected override void AnalysisFinished(Hub.PreparedMetricsReport metrics)
        {
            SetCommonKnowledge(metrics);
            SetReportParameters(metrics);
            SetDetailParameters();
        }

        private void SetCommonKnowledge(PreparedMetricsReport metrics)
        {
            sqiParameters.Classes = metrics.CommonKnowledge.NumberOfClasses;
            sqiParameters.Methods = metrics.CommonKnowledge.NumberOfMethods;
            sqiParameters.Namespaces = metrics.CommonKnowledge.NumberOfNamespaces;
            sqiParameters.Rloc = metrics.CommonKnowledge.RelevantLinesOfCode;
        }

        private void SetReportParameters(PreparedMetricsReport metrics)
        {
            _NamespacesInCycles.Value = SqiParameterType.Number(metrics.NumberOfNamespacesInCycleHotspots.Count());
            _ComplicatedMethods.Value = SqiParameterType.Number(metrics.Hotspots.OfCyclomaticComplexityOver(5).Count());
            _AverageComponentDependency.Value = SqiParameterType.Percentage(metrics.Rated.AverageComponentDependency);
            _BigClasses.Value = SqiParameterType.Number(metrics.Hotspots.OfClassSizeOver(20).Count());
            _BigMethods.Value = SqiParameterType.Number(metrics.Hotspots.OfMethodLengthOver(15).Count());
        }

        private void SetDetailParameters()
        {
            SqiParameterType.Percentage(Details.TestCoverage, v => _TestCoverage.Value = v);
            SqiParameterType.Number(Details.CompilerWarnings, v => _CompilerWarnings.Value = v);
        }
    }
}
