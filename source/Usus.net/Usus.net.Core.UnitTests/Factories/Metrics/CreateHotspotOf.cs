using System.Collections.Generic;
using andrena.Usus.net.Core.Hotspots;
using andrena.Usus.net.Core.Reports;
using System.Linq;

namespace Usus.net.Core.UnitTests.Factories.Metrics
{
    public static class CreateHotspotOf
    {
        public static IEnumerable<MethodMetricsReport> CyclomaticComplexity(params int[] ccs)
        {
            return Create.ManyMetrics(m => new MethodMetricsReport { CyclomaticComplexity = m }, ccs)
                .Hotspots().OfCyclomaticComplexity();
        }

        public static IEnumerable<MethodMetricsReport> MethodLength(params int[] mls)
        {
            return Create.ManyMetrics(m => new MethodMetricsReport { NumberOfLogicalLines = m }, mls)
                .Hotspots().OfMethodLength();
        }

        public static IEnumerable<TypeMetricsReport> ClassSize(params int[] css)
        {
            return Create.ManyMetrics(m => new TypeMetricsReport { FullName = Create.RandomName(), NumberOfMethods = m }, css)
                .Hotspots().OfClassSize();
        }

        public static IEnumerable<TypeMetricsReport> NumberOfNonStaticPublicFields(params int[] nspfs)
        {
            return Create.ManyMetrics(m => new TypeMetricsReport { FullName = Create.RandomName(), NumberOfNonStaticPublicFields = m }, nspfs)
                .Hotspots().OfNumberOfNonStaticPublicFields();
        }

        public static IEnumerable<TypeMetricsReport> CumulativeComponentDependency(params int[] ccds)
        {
            return Create.ManyMetrics(m => new TypeMetricsReport { FullName = Create.RandomName(), CumulativeComponentDependency = m }, ccds)
                .Hotspots().OfCumulativeComponentDependency();
        }

        public static IEnumerable<NamespaceMetricsReport> NumberOfNamespacesInCycle(params int[] cds)
        {
            return Create.ManyMetrics(m => new NamespaceMetricsReport { Name = Create.RandomName(), CyclicDependencies = Create.Default<string>(m) }, cds)
                .Hotspots().OfNamespacesInCycle();
        }
    }
}
