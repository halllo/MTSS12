using System;
using System.Collections.Generic;
using System.Linq;
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
            return MetricsReport(from metric in metrics
                                 select methodMetricsReport(metric));
        }

        public static MetricsReport MetricsReport(IEnumerable<MethodMetricsReport> methodMetrics)
        {
            var metricsReport = new MetricsReport();
            metricsReport.AddTypeReport(TypeMetrics(methodMetrics));
            return metricsReport;
        }

        internal static TypeMetricsWithMethodMetrics TypeMetrics(IEnumerable<MethodMetricsReport> methodMetrics)
        {
            var typeWithMethods = new TypeMetricsWithMethodMetrics();
            typeWithMethods.AddMethodReports(methodMetrics);
            return typeWithMethods;
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
