using System.Collections.Generic;

namespace andrena.Usus.net.Core.Metrics
{
    public class MetricsReport
    {
        private List<MethodMetricsReport> MethodReports;
        public IEnumerable<MethodMetricsReport> Methods
        {
            get { return MethodReports; }
        }

        public MetricsReport()
        {
            MethodReports = new List<MethodMetricsReport>();
        }

        internal void AddMethodReport(MethodMetricsReport methodMertics)
        {
            MethodReports.Add(methodMertics);
        }
    }
}
