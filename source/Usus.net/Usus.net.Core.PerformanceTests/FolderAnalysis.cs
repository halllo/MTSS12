using System;
using System.IO;
using System.Linq;
using andrena.Usus.net.Core;
using andrena.Usus.net.Core.Reports;

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
            Console.WriteLine(string.Format("{0}:\t{1}ms\t(analysis: {2}ms\tpostprocessing: {3}ms)",
                                            heading,
                                            times.CompleteTime.Milliseconds,
                                            times.AnalysisTime.Milliseconds,
                                            times.PostProcessingTime.Milliseconds));
        }
    }
}