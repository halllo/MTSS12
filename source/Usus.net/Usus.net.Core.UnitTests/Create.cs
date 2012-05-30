using System;
using System.Collections.Generic;
using andrena.Usus.net.Core.Hotspots;
using andrena.Usus.net.Core.Reports;

namespace Usus.net.Core.UnitTests
{
    public static class Create
    {
        public static IEnumerable<MethodMetricsReport> CyclomaticComplexityHotspots(params int[] ccs)
        {
            return ManyMetrics(m => new MethodMetricsReport { CyclomaticComplexity = m }, ccs)
                .Hotspots().OfCyclomaticComplexity();
        }

        public static IEnumerable<MethodMetricsReport> MethodLengthHotspots(params int[] mls)
        {
            return ManyMetrics(m => new MethodMetricsReport { NumberOfLogicalLines = m }, mls)
                .Hotspots().OfMethodLength();
        }

        public static double AverageRatedCyclomaticComplexity(params int[] ccs)
        {
            return ManyRatedMetrics(m => new MethodMetricsReport { CyclomaticComplexity = m }, ccs)
                .AverageRatedCyclomaticComplexity;
        }

        public static double AverageRatedMethodLength(params int[] mls)
        {
            return ManyRatedMetrics(m => new MethodMetricsReport { NumberOfLogicalLines = m }, mls)
                .AverageRatedMethodLength;
        }

        public static RatedMetrics ManyRatedMetrics(Func<int, MethodMetricsReport> methodMetricsReport, params int[] metrics)
        {
            return ManyMetrics(methodMetricsReport, metrics).Rate();
        }

        public static MetricsReport ManyMetrics(Func<int, MethodMetricsReport> methodMetricsReport, params int[] metrics)
        {
            MetricsReport metricsReport = new MetricsReport();
            foreach (int metric in metrics)
            {
                metricsReport.AddMethodReport(methodMetricsReport(metric));
            }
            return metricsReport;
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

        public static double RatedMethodLength(int numberOfLogicalLines, int numberOfStatements)
        {
            var metrics = new MethodMetricsReport
            {
                NumberOfLogicalLines = numberOfLogicalLines,
                NumberOfStatements = numberOfStatements
            };
            return metrics.Rate().RatedMethodLength;
        }
    }
}
