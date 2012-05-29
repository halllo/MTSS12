using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.Core.Hotspots
{
    public static class RatingFunctions
    {
        public static RatingFunctionLimits Limits { get; set; }

        static RatingFunctions()
        {
            Limits = new RatingFunctionLimits();
        }

        public static double RateCyclomaticComplexity(this MethodMetricsReport metrics)
        {
            if (metrics.CyclomaticComplexity > Limits.CyclomaticComplexity)
                return ((1.0 / Limits.CyclomaticComplexity) * metrics.CyclomaticComplexity) - 1;
            else
                return 0.0;
        }

        public static double RateMethodLength(this MethodMetricsReport metrics)
        {
            if (metrics.NumberOfLogicalLines > Limits.MethodLength)
                return ((1.0 / Limits.MethodLength) * metrics.NumberOfLogicalLines) - 1;
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
