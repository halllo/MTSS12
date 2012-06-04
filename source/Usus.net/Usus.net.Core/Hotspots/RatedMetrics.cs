using System.Collections.Generic;
using andrena.Usus.net.Core.Helper;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.Core.Hotspots
{
    public class RatedMetrics
    {
        public IEnumerable<RatedMethodMetrics> RatedMethods { get; private set; }
        public IEnumerable<RatedTypeMetrics> RatedTypes { get; private set; }

        public double AverageRatedCyclomaticComplexity { get; private set; }
        public double AverageRatedMethodLength { get; private set; }
        public double AverageRatedClassSize { get; private set; }

        internal RatedMetrics(MetricsReport metrics)
        {
            RatedMethods = metrics.Methods.SelectList(m => m.Rate());
            RatedTypes = metrics.Types.SelectList(m => m.Rate());

            AverageRatedCyclomaticComplexity = RatedMethods.AverageRating(m => m.RatedCyclomaticComplexity);
            AverageRatedMethodLength = RatedMethods.AverageRating(m => m.RatedMethodLength);
            AverageRatedClassSize = RatedTypes.AverageRating(m => m.RatedClassSize);
        }
    }
}
