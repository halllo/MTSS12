using System;

namespace andrena.Usus.net.Core.Reports
{
    public static partial class MetricsReportSearch
    {
        public class PropertyMetricsReport
        {
            public MethodMetricsReport Getter { get; internal set; }
            public MethodMetricsReport Setter { get; internal set; }
        }
    }
}