﻿using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.Graphs;

namespace andrena.Usus.net.Core.Reports
{
    public class MetricsReport
    {
        Dictionary<string, TypeMetricsWithMethodMetrics> typeReports;
        Dictionary<string, NamespaceMetricsWithTypeMetrics> namespaceReports;

        internal MutableGraph<TypeMetricsReport> GraphOfTypes { get; set; }
        internal MutableGraph<NamespaceMetricsWithTypeMetrics> GraphOfNamespaces { get; set; }

        public CommonReportKnowledge CommonKnowledge { get; private set; }

        public IEnumerable<MethodMetricsReport> Methods
        {
            get { return typeReports.Values.SelectMany(t => t.Methods); }
        }

        public IGraph<TypeMetricsReport> TypeGraph
        {
            get { return GraphOfTypes; }
        }
        public IEnumerable<TypeMetricsReport> Types
        {
            get { return typeReports.Values.Select(t => t.Itself); }
        }

        public IGraph<NamespaceMetricsReport> NamespaceGraph
        {
            get { return GraphOfNamespaces.Select(n => n.Itself); }
        }
        public IEnumerable<NamespaceMetricsReport> Namespaces
        {
            get { return namespaceReports.Values.Select(t => t.Itself); }
        }

        internal MetricsReport()
        {
            CommonKnowledge = new CommonReportKnowledge();
            typeReports = new Dictionary<string, TypeMetricsWithMethodMetrics>();
            namespaceReports = new Dictionary<string, NamespaceMetricsWithTypeMetrics>();
        }

        internal void AddNamespaceReport(NamespaceMetricsWithTypeMetrics namespaceMertics)
        {
            namespaceReports.Add(namespaceMertics.Itself.Name, namespaceMertics);
            namespaceMertics.Itself.CommonKnowledge = CommonKnowledge;
            CommonKnowledge.NumberOfNamespaces++;
        }

        internal void AddTypeReport(TypeMetricsWithMethodMetrics typeMertics)
        {
            typeReports.Add(typeMertics.Itself.FullName, typeMertics);
            ShareTheKnowledge(typeMertics);
            if (!typeMertics.Itself.CompilerGenerated) CommonKnowledge.NumberOfClasses++;
        }

        internal TypeMetricsReport TypeForName(string fullName)
        {
            return typeReports[fullName].Itself;
        }

        internal IEnumerable<MethodMetricsReport> MethodsOf(TypeMetricsReport type)
        {
            return typeReports[type.FullName].Methods;
        }

        internal IEnumerable<TypeMetricsReport> TypesOf(NamespaceMetricsReport namespaceMetrics)
        {
            return namespaceReports[namespaceMetrics.Name].Types;
        }

        private void ShareTheKnowledge(TypeMetricsWithMethodMetrics typeMertics)
        {
            typeMertics.Itself.CommonKnowledge = CommonKnowledge;
            foreach (var method in typeMertics.Methods) method.CommonKnowledge = CommonKnowledge;
        }
    }
}
