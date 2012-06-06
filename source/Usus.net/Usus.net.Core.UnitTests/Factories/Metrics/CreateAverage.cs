using andrena.Usus.net.Core.Reports;
using System;

namespace Usus.net.Core.UnitTests.Factories.Metrics
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
            return Create.ManyRatedMetrics(m => new TypeMetricsReport { FullName = Create.RandomName(), NumberOfMethods = m }, css)
                .AverageRatedClassSize;
        }

        public static double RatedNumberOfNonStaticPublicFields(params int[] nspfs)
        {
            return Create.ManyRatedMetrics(m => new TypeMetricsReport { FullName = Create.RandomName(), NumberOfNonStaticPublicFields = m }, nspfs)
                .AverageRatedNumberOfNonStaticPublicFields;
        }

        public static double CumulativeComponentDependency(params int[] ccds)
        {
            return Create.ManyRatedMetrics(m => new TypeMetricsReport { FullName = Create.RandomName(), CumulativeComponentDependency = m }, ccds)
                .AverageComponentDependency;
        }
    }
}
