using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.Reports;
using System;

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
            if (metrics.MethodLength > Limits.MethodLength)
                return ((1.0 / Limits.MethodLength) * metrics.MethodLength) - 1;
            else
                return 0.0;
        }

        public static double RateClassSize(this TypeMetricsReport metrics)
        {
            if (metrics.ClassSize > Limits.ClassSize)
                return ((1.0 / Limits.ClassSize) * metrics.ClassSize) - 1;
            else
                return 0.0;
        }

        public static double AverageRating<T>(this IEnumerable<T> ratedMethods, Func<T, double> metricSelector)
        {
            if (ratedMethods.Any())
                return ratedMethods.Average(metricSelector) * 100;
            else
                return 0;
        }
    }
}
