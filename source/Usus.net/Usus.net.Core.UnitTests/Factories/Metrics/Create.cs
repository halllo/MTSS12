﻿using System;
using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.Hotspots;
using andrena.Usus.net.Core.Reports;

namespace Usus.net.Core.UnitTests.Factories.Metrics
{
    public static class Create
    {
        public static RatedMetrics ManyRatedMetrics(Func<int, MethodMetricsReport> methodMetricsReport, params int[] metrics)
        {
            return ManyMetrics(methodMetricsReport, metrics).Rate();
        }

        public static RatedMetrics ManyRatedMetrics(Func<int, TypeMetricsReport> typeMetricsReport, params int[] metrics)
        {
            return ManyMetrics(typeMetricsReport, metrics).Rate();
        }

        public static RatedMetrics ManyRatedMetrics(Func<int, NamespaceMetricsReport> namespaceMetricsReport, params int[] metrics)
        {
            return ManyMetrics(namespaceMetricsReport, metrics).Rate();
        }

        public static MetricsReport ManyMetrics(Func<int, MethodMetricsReport> methodMetricsReport, params int[] metrics)
        {
            return MetricsReport(from metric in metrics
                                 select methodMetricsReport(metric));
        }

        public static MetricsReport ManyMetrics(Func<int, TypeMetricsReport> typeMetricsReport, params int[] metrics)
        {
            return MetricsReport(from metric in metrics
                                 select typeMetricsReport(metric));
        }

        public static MetricsReport ManyMetrics(Func<int, NamespaceMetricsReport> namespaceMetricsReport, params int[] metrics)
        {
            return MetricsReport(from metric in metrics
                                 select namespaceMetricsReport(metric));
        }

        public static MetricsReport MetricsReport(IEnumerable<MethodMetricsReport> methodMetrics)
        {
            var metricsReport = new MetricsReport();
            metricsReport.AddTypeReport(TypeMetrics(new TypeMetricsReport() { FullName = RandomName() }, methodMetrics));
            metricsReport.CommonKnowledge.NumberOfNamespaces = 1;
            return metricsReport;
        }

        public static MetricsReport MetricsReport(IEnumerable<TypeMetricsReport> typeMetrics)
        {
            var metricsReport = new MetricsReport();
            foreach (var typeMetric in typeMetrics)
                metricsReport.AddTypeReport(TypeMetrics(typeMetric, Enumerable.Empty<MethodMetricsReport>()));
            metricsReport.CommonKnowledge.NumberOfNamespaces = 1;
            return metricsReport;
        }

        public static MetricsReport MetricsReport(IEnumerable<NamespaceMetricsReport> namespaceMetrics)
        {
            var metricsReport = new MetricsReport();
            foreach (var namespaceMetric in namespaceMetrics)
                metricsReport.AddNamespaceReport(NamespaceMetrics(namespaceMetric, Enumerable.Empty<TypeMetricsReport>()));
            return metricsReport;
        }

        private static TypeMetricsWithMethodMetrics TypeMetrics(TypeMetricsReport typeMetrics, IEnumerable<MethodMetricsReport> methodMetrics)
        {
            var typeWithMethods = new TypeMetricsWithMethodMetrics() { Itself = typeMetrics };
            typeWithMethods.AddMethodReports(methodMetrics);
            return typeWithMethods;
        }

        private static NamespaceMetricsWithTypeMetrics NamespaceMetrics(NamespaceMetricsReport namespaceMetrics, IEnumerable<TypeMetricsReport> typeMetrics)
        {
            var namespaceWithTypes = new NamespaceMetricsWithTypeMetrics() { Itself = namespaceMetrics };
            foreach (var typeMetric in typeMetrics) namespaceWithTypes.AddTypeReport(typeMetric);
            return namespaceWithTypes;
        }

        static Random randomizer = new Random();
        internal static string RandomName()
        {
            return randomizer.NextDouble().ToString();
        }

        internal static IEnumerable<T> Default<T>(int count)
        {
            return Enumerable.Repeat(default(T), count);
        }
    }
}
