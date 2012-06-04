using System.Collections.Generic;
using andrena.Usus.net.Core.Hotspots;
using andrena.Usus.net.Core.Reports;

namespace Usus.net.Core.UnitTests.Factories
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
            return Create.ManyMetrics(m => new TypeMetricsReport { NumberOfMethods = m }, css)
                .Hotspots().OfClassSize();
        }
    }
}
