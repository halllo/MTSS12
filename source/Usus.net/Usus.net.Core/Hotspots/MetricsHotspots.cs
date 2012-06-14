using System.Collections.Generic;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.Core.Hotspots
{
    public class MetricsHotspots
    {
        public MetricsReport Metrics { get; private set; }
        
        internal MetricsHotspots(MetricsReport metrics)
        {
            Metrics = metrics;
        }

        public IEnumerable<MethodMetricsReport> OfCyclomaticComplexity()
        {
            return Metrics.MethodsOverLimit(m => m.CyclomaticComplexity, l => l.CyclomaticComplexity);
        }

        public IEnumerable<MethodMetricsReport> OfMethodLength()
        {
            return Metrics.MethodsOverLimit(m => m.MethodLength, l => l.MethodLength);
        }

        public IEnumerable<TypeMetricsReport> OfClassSize()
        {
            return Metrics.TypesOverLimit(m => m.ClassSize, l => l.ClassSize);
        }

        public IEnumerable<TypeMetricsReport> OfNumberOfNonStaticPublicFields()
        {
            return Metrics.TypesOverLimit(m => m.NumberOfNonStaticPublicFields, l => l.NumberOfNonStaticPublicFields);
        }

        public IEnumerable<TypeMetricsReport> OfCumulativeComponentDependency()
        {
            return Metrics.TypesOverLimit(m => m.CumulativeComponentDependency, l => l.CumulativeComponentDependency);
        }

        public IEnumerable<NamespaceMetricsReport> OfNumberOfNamespacesInCycle()
        {
            return Metrics.NamespacesOverLimit(m => m.NumberOfNamespacesInCycle, l => l.NumberOfNamespacesInCycle);
        }
    }
}
