using andrena.Usus.net.Core.Metrics;

namespace andrena.Usus.net.Core.Hotspots
{
    public class RatedMethodMetrics
    {
        public string Name { get; private set; }
        public string Signature { get; private set; }
        public double RatedCyclomaticComplexity { get; private set; }
        public double RatedMethodLength { get; private set; }

        public RatedMethodMetrics(MethodMetricsReport metrics)
        {
            Name = metrics.Name;
            Signature = metrics.Signature;
            RatedCyclomaticComplexity = metrics.RateCyclomaticComplexity();
            RatedMethodLength = metrics.RateMethodLength();
        }
    }
}
