using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.Metrics;

namespace andrena.Usus.net.Core.Hotspots
{
    public static class RatingFunctions
    {
        public static double RateCyclomaticComplexity(this MethodMetricsReport metrics)
        {
            if (metrics.CyclomaticComplexity > 4)
                return ((1.0 / 4) * metrics.CyclomaticComplexity) - 1;
            else
                return 0.0;
        }

        public static double RateMethodLength(this MethodMetricsReport metrics)
        {
            if (metrics.NumberOfLogicalLines > 9)
                return ((1.0 / 9) * metrics.NumberOfLogicalLines) - 1;
            else
                return 0.0;
        }

        public static double AverageRatedCyclomaticComplexities(this IEnumerable<RatedMethodMetrics> ratedMethods)
        {
            if (ratedMethods.Any())
                return ratedMethods.Average(m => m.RatedCyclomaticComplexity) * 100;
            else
                return 0;
        }

        public static double AverageRatedMethodLengths(this IEnumerable<RatedMethodMetrics> ratedMethods)
        {
            if (ratedMethods.Any())
                return ratedMethods.Average(m => m.RatedMethodLength) * 100;
            else
                return 0;
        }
    }
}
