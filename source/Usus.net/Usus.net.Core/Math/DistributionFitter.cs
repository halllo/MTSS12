
namespace andrena.Usus.net.Core.Math
{
    public static class DistributionFitter
    {
        public static double FitExponentialDistribution(this IHistogram histogram)
        {
            return 1.0 / histogram.Mean;
        }
    }
}
