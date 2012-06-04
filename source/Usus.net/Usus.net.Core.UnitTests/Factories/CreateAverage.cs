using andrena.Usus.net.Core.Reports;

namespace Usus.net.Core.UnitTests.Factories
{
    public static class CreateAverage
    {
        public static double RatedCyclomaticComplexity(params int[] ccs)
        {
            return Create.ManyRatedMetrics(m => new MethodMetricsReport { CyclomaticComplexity = m }, ccs)
                .AverageRatedCyclomaticComplexity;
        }

        public static double RatedMethodLength(params int[] mls)
        {
            return Create.ManyRatedMetrics(m => new MethodMetricsReport { NumberOfLogicalLines = m }, mls)
                .AverageRatedMethodLength;
        }

        public static double RatedClassSize(params int[] css)
        {
            return Create.ManyRatedMetrics(m => new TypeMetricsReport { NumberOfMethods = m }, css)
                .AverageRatedClassSize;
        }
    }
}
