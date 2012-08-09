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
    }
}