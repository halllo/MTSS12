using System.Collections.Generic;

namespace andrena.Usus.net.Core.Reports
{
    public class MetricsReport
    {
        private List<MethodMetricsReport> MethodReports;
        public IEnumerable<MethodMetricsReport> Methods
        {
            get { return MethodReports; }
        }

        internal MetricsReport()
        {
            MethodReports = new List<MethodMetricsReport>();
        }

        internal void AddMethodReport(MethodMetricsReport methodMertics)
        {
            MethodReports.Add(methodMertics);
        }
    }
}
