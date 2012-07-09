using System;
using System.Collections.ObjectModel;
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

        internal Action<LineLocation> RequestLineHandler()
        {
            return line => DisplayMetricsOfMethodAtDefinition(line);
        }

        private void DisplayMetricsOfMethodAtDefinition(LineLocation location)
        {
            if (lastLocation.IsSameAs(location)) return;
            var method = GetMethodOfDefiniton(location);
            if (method != null) DisplayMetrics(method);
        }

        private MethodAndTypeMetrics GetMethodOfDefiniton(LineLocation location)
        {
            lastLocation = location;
            return metrics.MethodOfLine(location);
        }

        private void DisplayMetrics(MethodAndTypeMetrics method)
        {
            Entries.Clear();
            foreach (var info in method.Info)
            {
                Entries.Add(new CurrentEntry { Metric = info.Item1, Value = info.Item2 });
            }
        }
    }
}
