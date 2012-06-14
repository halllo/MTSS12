using System.Collections.Generic;
using System.Linq;

namespace andrena.Usus.net.Core.Reports
{
    internal class NamespaceMetricsWithTypeMetrics
    {
        public NamespaceMetricsReport Itself { get; internal set; }

        List<TypeMetricsReport> TypeReports;
        public IEnumerable<TypeMetricsReport> Types
        {
            get { return Types; }
        }

        internal NamespaceMetricsWithTypeMetrics()
        {
            TypeReports = new List<TypeMetricsReport>();
        }

        internal void AddType(TypeMetricsReport typeReport)
        {
            TypeReports.Add(typeReport);
        }

        internal void AddTypes(IEnumerable<NamespaceMetricsWithTypeMetrics> typeReports)
        {
            TypeReports.AddRange(typeReports.SelectMany(n => n.TypeReports));
        }
    }
}
