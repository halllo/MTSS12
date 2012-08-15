using System;
using System.IO;
using System.Linq;
using andrena.Usus.net.Core;
using andrena.Usus.net.Core.Reports;
using andrena.Usus.net.Core.Prepared;

namespace Usus.net.Core.PerformanceTests
{
    public class FolderAnalysis
    {
        private string[] In(string path)
        {
            return Directory.EnumerateFiles(path, "*.dll").ToArray();
        }

        protected MetricsReport AnalyzeAssembliesIn(string ususNetCorePerformancetestsSamplesPdbissueBuild1)
        {
            return Analyze.PortableExecutables(In(ususNetCorePerformancetestsSamplesPdbissueBuild1));
        }

        protected MetricsReport AnalyzeInParallelAssembliesIn(string ususNetCorePerformancetestsSamplesPdbissueBuild1)
        {
            return AnalyzeParallel.PortableExecutables(In(ususNetCorePerformancetestsSamplesPdbissueBuild1));
        }

        protected void OutputAnalysisTimes(string heading, MetricsReport metrics)
        {
            var times = new AnalyzeTimes(metrics);
            Console.WriteLine(string.Format("{0} ({1} RLOC, {2} assemblies):\t{3}s\t(analysis: {4}s\tpostprocessing: {5}s)",
                                            heading,
                                            metrics.CommonKnowledge.RelevantLinesOfCode,
                                            metrics.CommonKnowledge.NumberOfAssemblies,
                                            times.CompleteTime.TotalSeconds,
                                            times.AnalysisTime.TotalSeconds,
                                            times.PostProcessingTime.TotalSeconds));
        }

        protected void OutputAnalysisMetrics(string heading, MetricsReport metrics)
        {
            var prepared = new PreparedMetricsFactory().Prepare(metrics);
            Console.WriteLine(string.Format("{0} ({1} RLOC):\tACD: {2};\tCS: {3};\tCC: {4};\tML: {5};\tPF: {6};\tCN: {7};",
                                            heading,
                                            prepared.CommonKnowledge.RelevantLinesOfCode,
                                            prepared.Rated.AverageComponentDependency,
                                            prepared.Rated.AverageRatedClassSize,
                                            prepared.Rated.AverageRatedCyclomaticComplexity,
                                            prepared.Rated.AverageRatedMethodLength,
                                            prepared.Rated.AverageRatedNumberOfNonStaticPublicFields,
                                            prepared.Rated.NamespacesWithCyclicDependencies));
            Console.WriteLine(string.Format("Hotspots:\tACD: {0};\tCS: {1};\tCC: {2};\tML: {3};\tPF: {4};\tCN: {5};",
                                            prepared.CumulativeComponentDependencyHotspots.Count(),
                                            prepared.ClassSizeHotspots.Count(),
                                            prepared.CyclomaticComplexityHotspots.Count(),
                                            prepared.MethodLengthHotspots.Count(),
                                            prepared.NumberOfNonStaticPublicFieldsHotspots.Count(),
                                            prepared.NumberOfNamespacesInCycleHotspots.Count()));
            Console.WriteLine(string.Format("Distributions:\tACD: {0};\tCS: {1};\tCC: {2};\tML: {3};\tPF: {4};\tCN: {5};",
                                            prepared.CumulativeComponentDependencyHistogram.GeometricalFit.Parameter,
                                            prepared.ClassSizeHistogram.GeometricalFit.Parameter,
                                            prepared.CyclomaticComplexityHistogram.GeometricalFit.Parameter,
                                            prepared.MethodLengthHistogram.GeometricalFit.Parameter,
                                            prepared.NumberOfNonStaticPublicFieldsHistogram.GeometricalFit.Parameter,
                                            prepared.NumberOfNamespacesInCycleHistogram.GeometricalFit.Parameter));
        }
    }
}