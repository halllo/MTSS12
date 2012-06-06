using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.Core.Hotspots
{
    internal static class RatingFunctions
    {
        public static RatingFunctionLimits Limits { get; set; }

        static RatingFunctions()
        {
            Limits = new RatingFunctionLimits();
        }

        public static double RateCyclomaticComplexity(this MethodMetricsReport metrics)
        {
            if (metrics.CyclomaticComplexity > Limits.CyclomaticComplexity(metrics.NumberOfClasses()))
                return ((1.0 / Limits.CyclomaticComplexity(metrics.NumberOfClasses())) * metrics.CyclomaticComplexity) - 1;
            else
                return 0.0;
        }

        public static double RateMethodLength(this MethodMetricsReport metrics)
        {
            if (metrics.MethodLength > Limits.MethodLength(metrics.NumberOfClasses()))
                return ((1.0 / Limits.MethodLength(metrics.NumberOfClasses())) * metrics.MethodLength) - 1;
            else
                return 0.0;
        }

        public static double RateClassSize(this TypeMetricsReport metrics)
        {
            if (metrics.ClassSize > Limits.ClassSize(metrics.NumberOfClasses()))
                return ((1.0 / Limits.ClassSize(metrics.NumberOfClasses())) * metrics.ClassSize) - 1;
            else
                return 0.0;
        }

        public static double RateNumberOfNonStaticPublicFields(this TypeMetricsReport metrics)
        {
            if (metrics.NumberOfNonStaticPublicFields > Limits.NumberOfNonStaticPublicFields(metrics.NumberOfClasses()))
                return 1.0;
            else
                return 0.0;
        }
        
        private static int NumberOfClasses(this MethodMetricsReport metrics)
        {
            return metrics.CommonKnowledge.NumberOfClasses;
        }

        private static int NumberOfClasses(this TypeMetricsReport metrics)
        {
            return metrics.CommonKnowledge.NumberOfClasses;
        } 
    }
}
