using System.Collections.Generic;
using System.Linq;

namespace andrena.Usus.net.Core.Reports
{
    public class MetricsReport
    {
        Dictionary<TypeMetricsReport, TypeMetricsWithMethodMetrics> TypeReports;
        
        public IEnumerable<MethodMetricsReport> Methods
        {
            get { return TypeReports.Values.SelectMany(t => t.Methods); }
        }

        public IEnumerable<TypeMetricsReport> Types
        {
            get { return TypeReports.Values.Select(t => t.Itself); }
        }

        internal MetricsReport()
        {
            TypeReports = new Dictionary<TypeMetricsReport, TypeMetricsWithMethodMetrics>();
        }

        internal void AddTypeReport(TypeMetricsWithMethodMetrics typeMertics)
        {
            TypeReports.Add(typeMertics.Itself, typeMertics);
        }

        public IEnumerable<MethodMetricsReport> MethodsOf(TypeMetricsReport type)
        {
            return TypeReports[type].Methods;
        }
    }
}
