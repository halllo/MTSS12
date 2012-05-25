using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.Core.Hotspots
{
    public static class MethodHotspots
    {
        public static RatedMetrics Rate(this MetricsReport metrics)
        {
            return new RatedMetrics(metrics);
        }

        public static RatedMethodMetrics Rate(this MethodMetricsReport metrics)
        {
            return new RatedMethodMetrics(metrics);
        }
    }
}
