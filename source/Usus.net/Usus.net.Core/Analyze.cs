using System.Linq;
using System.Reflection;
using andrena.Usus.net.Core.Metrics;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.Core
{
    public static class Analyze
    {
        public static MetricsReport Me()
        {
            return PortableExecutable(Assembly.GetCallingAssembly());
        }

        public static MetricsReport PortableExecutable(Assembly asm)
        {
            return PortableExecutables(asm.Location);
        }

        public static MetricsReport PortableExecutables(params string[] asmFiles)
        {
            var report = MetricsReport.Of(asmFiles.Select(AnalyseFile));
            report.PostProcess();
            return report;
        }
        
        internal static MetricsReport AnalyseFile(string asmFile)
        {
            var mc = new MetricsCollector();
            mc.Analyze(asmFile);
            return mc.Report;
        }

        internal static void PostProcess(this MetricsReport metrics)
        {
            PostProcessTypeDependencies.Of(metrics);
            PostProcessNamespaceDependencies.Of(metrics);
        }
    }
}
