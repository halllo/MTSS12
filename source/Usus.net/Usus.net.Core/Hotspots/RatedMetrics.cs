using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.Metrics;

namespace andrena.Usus.net.Core.Hotspots
{
    public class RatedMetrics
    {
        public IEnumerable<RatedMethodMetrics> RatedMethods {get; private set; }

        public double AverageRatedCyclomaticComplexity { get; private set; }
        public double AverageRatedMethodLength { get; private set; }

        public RatedMetrics(MetricsReport metrics)
        {
            RatedMethods = RatedMethodMetrics(metrics);
            AverageRatedCyclomaticComplexity = RatedMethods.AverageRatedCyclomaticComplexities();
            AverageRatedMethodLength = RatedMethods.AverageRatedMethodLengths();
        }

        private static IEnumerable<RatedMethodMetrics> RatedMethodMetrics(MetricsReport metrics)
        {
            return (from m in metrics.Methods
                    select m.Rate()).ToList();
        }
    }
}
