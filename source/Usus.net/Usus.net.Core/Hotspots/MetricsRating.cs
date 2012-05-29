using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.Core.Hotspots
{
    public static class MetricsRating
    {
        public static RatedMetrics Rate(this MetricsReport metrics)
        {
            return new RatedMetrics(metrics);
        }

        public static RatedMethodMetrics Rate(this MethodMetricsReport metrics)
        {
            return new RatedMethodMetrics(metrics);
        }

        public static MetricsHotspots Hotspots(this MetricsReport metrics)
        {
            return new MetricsHotspots(metrics);
        }
    }
}
