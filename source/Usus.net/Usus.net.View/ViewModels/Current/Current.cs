using System;
using System.Collections.ObjectModel;
using System.Linq;
using andrena.Usus.net.Core.Reports;

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

        public Func<LineLocation> RequestCurosrPosition { private get; set; }

        internal void RequestMetrics()
        {
            if (EnoughDataAvailable()) DisplayMetricsOfMethod();
        }

        private bool EnoughDataAvailable()
        {
            return RequestCurosrPosition != null
                && !lastLocation.IsSameAs(RequestCurosrPosition())
                && metrics != null;
        }

        private void DisplayMetricsOfMethod()
        {
            var method = GetMethodOf(RequestCurosrPosition());
            if (method != null) DisplayMetrics(method);
        }

        private MethodMetricsReport GetMethodOf(LineLocation location)
        {
            lastLocation = location;
            return (from method in metrics.Methods
                    where !method.CompilerGenerated
                    where method.SourceLocation.IsAvailable
                    where method.SourceLocation.Filename == location.File
                    where method.SourceLocation.Line <= location.Line
                    select method).LastOrDefault();
        }

        private void DisplayMetrics(MethodMetricsReport method)
        {
            Entries.Clear();
            Entries.Add(new CurrentEntry { Metric = "Name", Value = method.Name });
            Entries.Add(new CurrentEntry { Metric = "Length", Value = method.MethodLength.ToString() });
            Entries.Add(new CurrentEntry { Metric = "Cyclomatic Complexity", Value = method.CyclomaticComplexity.ToString() });
        }
    }
}
