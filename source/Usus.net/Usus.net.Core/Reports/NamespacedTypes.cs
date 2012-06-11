using System.Collections.Generic;
using System.Linq;

namespace andrena.Usus.net.Core.Reports
{
    public class NamespacedTypes
    {
        List<TypeMetricsReport> Types;

        public string Namespace { get; private set; }
        public IEnumerable<TypeMetricsReport> TypeReports { get { return Types; } }

        public NamespacedTypes(string namespaceName)
        {
            Namespace = namespaceName;
            Types = new List<TypeMetricsReport>();
        }

        internal void AddType(TypeMetricsReport typeReport)
        {
            Types.Add(typeReport);
        }

        internal void AddTypes(IEnumerable<NamespacedTypes> typeReports)
        {
            Types.AddRange(typeReports.SelectMany(n => n.TypeReports));
        }
    }
}
