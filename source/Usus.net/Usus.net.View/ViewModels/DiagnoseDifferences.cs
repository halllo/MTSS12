using System;
using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.View.ViewModels
{
    public class DiagnoseDifferences : AnalysisAwareViewModel
    {
        List<List<MethodMetricsReport>> metricsRemembered;
        List<Tuple<MethodMetricsReport, MethodMetricsReport>> _Differences;
        public IEnumerable<Tuple<MethodMetricsReport, MethodMetricsReport>> Differences { get { return _Differences; } }

        public DiagnoseDifferences()
        {
            metricsRemembered = new List<List<MethodMetricsReport>>();
            _Differences = new List<Tuple<MethodMetricsReport, MethodMetricsReport>>();
        }

        protected override void AnalysisStarted()
        {
        }

        protected override void AnalysisFinished(Hub.PreparedMetricsReport metrics)
        {
            metricsRemembered.Add(metrics.Report.Methods.ToList());
            if (metricsRemembered.Count > 1) RememberNewDifferences();
            OutputAllDifferences();
        }

        private void OutputAllDifferences()
        {
            foreach (var tuple in Differences)
                Console.WriteLine("{0}\t{1}\t{2}", tuple.Item1.Signature, tuple.Item1.MethodLength, tuple.Item2.MethodLength);
        }

        private void RememberNewDifferences()
        {
            var masterList = metricsRemembered.Last().Zip(metricsRemembered.Skip(metricsRemembered.Count - 2).First(), (m1, m2) => Tuple.Create(m1, m2));
            _Differences.AddRange(masterList.Where(t => t.Item1.MethodLength != t.Item2.MethodLength));
        }
    }
}
