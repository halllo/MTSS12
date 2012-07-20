﻿using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.Hotspots;
using andrena.Usus.net.Core.Math;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.View.Hub
{
    public class PreparedMetricsReport
    {
        public MetricsReport Report { get; private set; }
        public MetricsHotspots Hotspots { get; private set; }
        public RatedMetrics Rated { get; private set; }
        public CommonReportKnowledge CommonKnowledge { get; private set; }

        public Distribution ClassSizeHistogram { get; private set; }
        public Distribution CumulativeComponentDependencyHistogram { get; private set; }
        public Distribution CyclomaticComplexityHistogram { get; private set; }
        public Distribution MethodLengthHistogram { get; private set; }
        public Distribution NumberOfNamespacesInCycleHistogram { get; private set; }
        public Distribution NumberOfNonStaticPublicFieldsHistogram { get; private set; }

        public IEnumerable<TypeMetricsReport> ClassSizeHotspots { get; private set; }
        public IEnumerable<TypeMetricsReport> CumulativeComponentDependencyHotspots { get; private set; }
        public IEnumerable<MethodMetricsReport> CyclomaticComplexityHotspots { get; private set; }
        public IEnumerable<MethodMetricsReport> MethodLengthHotspots { get; private set; }
        public IEnumerable<TypeMetricsReport> NumberOfNonStaticPublicFieldsHotspots { get; private set; }
        public IEnumerable<NamespaceMetricsReport> NumberOfNamespacesInCycleHotspots { get; private set; }
        
        public PreparedMetricsReport(MetricsReport metrics)
        {
            Report = metrics;
            Prepare();
        }

        private void Prepare()
        {
            CommonKnowledge = Report.CommonKnowledge;
            Rated = Report.Rate();
            Hotspots = Report.Hotspots();
            PrepareHotspots();
            PrepareHistograms();
        }

        private void PrepareHistograms()
        {
            ClassSizeHistogram = Report.TypeDistribution(t => t.ClassSize);
            CumulativeComponentDependencyHistogram = Report.TypeDistribution(t => t.CumulativeComponentDependency);
            CyclomaticComplexityHistogram = Report.MethodDistribution(m => m.CyclomaticComplexity);
            MethodLengthHistogram = Report.MethodDistribution(m => m.MethodLength);
            NumberOfNamespacesInCycleHistogram = Report.NamespaceDistribution(n => n.NumberOfNamespacesInCycle);
            NumberOfNonStaticPublicFieldsHistogram = Report.TypeDistribution(t => t.NumberOfNonStaticPublicFields);
        }

        private void PrepareHotspots()
        {
            ClassSizeHotspots = Hotspots.OfClassSize().ToList();
            CumulativeComponentDependencyHotspots = Hotspots.OfCumulativeComponentDependency().ToList();
            CyclomaticComplexityHotspots = Hotspots.OfCyclomaticComplexity().ToList();
            MethodLengthHotspots = Hotspots.OfMethodLength().ToList();
            NumberOfNonStaticPublicFieldsHotspots = Hotspots.OfNumberOfNonStaticPublicFields().ToList();
            NumberOfNamespacesInCycleHotspots = Hotspots.OfNamespacesInCycle().ToList();
        }
    }
}
