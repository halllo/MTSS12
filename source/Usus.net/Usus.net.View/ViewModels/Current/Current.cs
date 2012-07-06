using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using andrena.Usus.net.Core.Reports;
using andrena.Usus.net.View.ExtensionPoints;

namespace andrena.Usus.net.View.ViewModels.Current
{
    public class Current : AnalysisAwareViewModel
    {
        MetricsReport metrics;
        LineLocation lastLocation = new LineLocation();

        public ObservableCollection<CurrentEntry> Entries { get; private set; }

        public Current()
        {
            Entries = new ObservableCollection<CurrentEntry>();
        }

        protected override void AnalysisStarted()
        {
        }

        protected override void AnalysisFinished(MetricsReport metrics)
        {
            this.metrics = metrics;
        }

        internal IKnowSourceLocation SourceLocations { private get; set; }

        internal void RequestMetrics()
        {
            if (EnoughDataAvailable()) DisplayMetricsOfMethod();
        }

        private bool EnoughDataAvailable()
        {
            return SourceLocations != null
                && !lastLocation.IsSameAs(SourceLocations.GetCursorPositon())
                && metrics != null;
        }

        private void DisplayMetricsOfMethod()
        {
            var method = GetLastMethodOf(SourceLocations.GetCursorPositon());
            if (method != null) DisplayMetrics(method);
        }

        private MethodAndTypeMetrics GetLastMethodOf(LineLocation location)
        {
            lastLocation = location;
            return (GetMethodOfLine(location)).LastOrDefault();
        }

        private IEnumerable<MethodAndTypeMetrics> GetMethodOfLine(LineLocation location)
        {
            return from type in metrics.Types
                   from method in metrics.MethodsOfType(type)
                   where IsMethodAtLine(method, location)
                   select new MethodAndTypeMetrics { Method = method, Type = type };
        }

        private bool IsMethodAtLine(MethodMetricsReport method, LineLocation location)
        {
            return !method.CompilerGenerated
                && method.SourceLocation.IsAvailable
                && String.Compare(method.SourceLocation.Filename, location.File, true) == 0
                && method.SourceLocation.Line <= location.Line;
        }

        private void DisplayMetrics(MethodAndTypeMetrics method)
        {
            Entries.Clear();
            DisplayMethodMetrics(method.Method);
            DisplayTypeMetrics(method.Type);
        }

        private void DisplayMethodMetrics(MethodMetricsReport method)
        {
            Entries.Add(new CurrentEntry { Metric = "Name", Value = method.Name });
            Entries.Add(new CurrentEntry { Metric = "Length", Value = method.MethodLength.ToString() });
            Entries.Add(new CurrentEntry { Metric = "Cyclomatic Complexity", Value = method.CyclomaticComplexity.ToString() });
        }

        private void DisplayTypeMetrics(TypeMetricsReport type)
        {
            Entries.Add(new CurrentEntry { Metric = "(Class) Size", Value = type.ClassSize.ToString() });
            Entries.Add(new CurrentEntry { Metric = "(Class) Non-static public fields", Value = type.NumberOfNonStaticPublicFields.ToString() });
            Entries.Add(new CurrentEntry { Metric = "(Class) Direct Dependencies", Value = type.InterestingDirectDependencies.Count().ToString() });
            Entries.Add(new CurrentEntry { Metric = "(Class) Cumulative Component Dependency", Value = type.CumulativeComponentDependency.ToString() });
        }
    }
}
