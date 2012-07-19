using MathNet.Numerics.Statistics;

namespace andrena.Usus.net.Core.Math
{
    public class FittingReport
    {
        DescriptiveStatistics statistics;
        internal FittingReport(IHistogram histogram)
        {
            statistics = new DescriptiveStatistics(histogram.Data);
        }

        public double ForGeometricalDistribution
        {
            get
            {
                return System.Math.Min(1.0, 1.0 / statistics.Mean);
            }
        }
    }
}
