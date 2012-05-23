using System.Collections.Generic;

namespace andrena.Usus.net.Core.Metrics
{
    public class MetricsReport
    {
        internal List<MethodMetricsReport> MethodReports { get; private set; }
        public IEnumerable<MethodMetricsReport> Methods
        {
            get { return MethodReports; }
        }

        public MetricsReport()
        {
            MethodReports = new List<MethodMetricsReport>();
        }
    }
}
