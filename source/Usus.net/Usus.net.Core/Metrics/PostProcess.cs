using System.Collections.Generic;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.Core.Metrics
{
    internal static class PostProcess
    {
        public static MetricsReport Metrics(MetricsReport metrics)
        {
            foreach (var type in metrics.Types)
            {
                //do some post processing later
            }
            return metrics;
        }
    }
}
