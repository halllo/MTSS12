using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.Graphs;

namespace andrena.Usus.net.Core.Reports
{
    public class MetricsReport
    {
        Dictionary<string, TypeMetricsWithMethodMetrics> TypeReports;
        
        public CommonReportKnowledge CommonKnowledge { get; private set; }
        public Graph<TypeMetricsReport> TypeGraph { get; internal set; }
        public Graph<NamespacedTypes> NamespaceGraph { get; internal set; }
        
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
            TypeReports = new Dictionary<string, TypeMetricsWithMethodMetrics>();
            CommonKnowledge = new CommonReportKnowledge();
        }

        internal void AddTypeReport(TypeMetricsWithMethodMetrics typeMertics)
        {
            TypeReports.Add(typeMertics.Itself.FullName, typeMertics);
            ShareTheKnowledge(typeMertics);
            if (!typeMertics.Itself.CompilerGenerated) CommonKnowledge.NumberOfClasses++;
        }

        internal TypeMetricsReport TypeForName(string fullName)
        {
            return TypeReports[fullName].Itself;
        }

        internal IEnumerable<MethodMetricsReport> MethodsOf(TypeMetricsReport type)
        {
            return TypeReports[type.FullName].Methods;
        }

        private void ShareTheKnowledge(TypeMetricsWithMethodMetrics typeMertics)
        {
            typeMertics.Itself.CommonKnowledge = CommonKnowledge;
            foreach (var method in typeMertics.Methods) method.CommonKnowledge = CommonKnowledge;
        }
    }
}
