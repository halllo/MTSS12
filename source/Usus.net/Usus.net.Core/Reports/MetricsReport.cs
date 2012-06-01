using System.Collections.Generic;
using System.Linq;

namespace andrena.Usus.net.Core.Reports
{
    public class MetricsReport
    {
        private List<TypeMetricsWithMethodMetrics> TypeReports;
        
        public IEnumerable<MethodMetricsReport> Methods
        {
            get { return TypeReports.SelectMany(t => t.Methods); }
        }

        public IEnumerable<TypeMetricsReport> Types
        {
            get { return TypeReports.Select(t => t.Metrics); }
        }

        internal MetricsReport()
        {
            TypeReports = new List<TypeMetricsWithMethodMetrics>();
        }

        internal void AddTypeReport(TypeMetricsWithMethodMetrics typeMertics)
        {
            TypeReports.Add(typeMertics);
        }
    }
}
