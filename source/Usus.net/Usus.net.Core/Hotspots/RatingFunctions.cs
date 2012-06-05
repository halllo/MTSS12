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
                return (((1.0 / Limits.CyclomaticComplexity) * metrics.CyclomaticComplexity) - 1) * 100;
            else
                return 0.0;
        }

        public static double RateMethodLength(this MethodMetricsReport metrics)
        {
            if (metrics.MethodLength > Limits.MethodLength)
                return (((1.0 / Limits.MethodLength) * metrics.MethodLength) - 1) * 100;
            else
                return 0.0;
        }

        public static double RateClassSize(this TypeMetricsReport metrics)
        {
            if (metrics.ClassSize > Limits.ClassSize)
                return (((1.0 / Limits.ClassSize) * metrics.ClassSize) - 1) * 100;
            else
                return 0.0;
        }

        public static double RateNumberOfNonStaticPublicFields(this TypeMetricsReport metrics)
        {
            if (metrics.NumberOfNonStaticPublicFields > Limits.NumberOfNonStaticPublicFields)
                return 100.0;
            else
                return 0.0;
        }
    }
}
