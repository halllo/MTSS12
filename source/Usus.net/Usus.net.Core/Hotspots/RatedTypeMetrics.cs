using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.Core.Hotspots
{
    public class RatedTypeMetrics
    {
        public string Name { get; private set; }
        public string FullName { get; private set; }
        public double RatedClassSize { get; private set; }

        internal RatedTypeMetrics(TypeMetricsReport metrics)
        {
            Name = metrics.Name;
            FullName = metrics.FullName;
            RatedClassSize = metrics.RateClassSize();
        }
    }
}
