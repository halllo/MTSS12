using System;
using andrena.Usus.net.Core.Hotspots;
using andrena.Usus.net.Core.Reports;

namespace Usus.net.Core.UnitTests
{
    public static class Create
    {
        public static double AverageRatedCyclomaticComplexity(params int[] ccs)
        {
            return AverageRatedMetric(m => new MethodMetricsReport { CyclomaticComplexity = m }, ccs)
                .AverageRatedCyclomaticComplexity;
        }

        public static double AverageRatedMethodLength(params int[] mls)
        {
            return AverageRatedMetric(m => new MethodMetricsReport { NumberOfLogicalLines = m }, mls)
                .AverageRatedMethodLength;
        }

        private static RatedMetrics AverageRatedMetric(Func<int, MethodMetricsReport> methodMetricsReport, params int[] metrics)
        {
            MetricsReport metricsReport = new MetricsReport();
            foreach (int metric in metrics)
            {
                metricsReport.AddMethodReport(methodMetricsReport(metric));
            }
            return metricsReport.Rate();
        }

        public static double RatedCyclomaticComplexity(int cc)
        {
            var metrics = new MethodMetricsReport { CyclomaticComplexity = cc };
            return metrics.Rate().RatedCyclomaticComplexity;
        }

        public static double RatedMethodLength(int ml)
        {
            var metrics = new MethodMetricsReport { NumberOfLogicalLines = ml };
            return metrics.Rate().RatedMethodLength;
        }
    }
}
