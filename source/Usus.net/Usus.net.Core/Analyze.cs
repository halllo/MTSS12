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
            return PortableExecutable(asm.Location);
        }

        public static MetricsReport PortableExecutable(string asmPath)
        {
            MetricsCollector mc = new MetricsCollector();
            mc.Analyze(asmPath);
            mc.Report.PostProcess();
            return mc.Report;
        }

        private static void PostProcess(this MetricsReport metrics)
        {
            PostProcessTypeDependencies.Of(metrics);
            PostProcessNamespaceDependencies.Of(metrics);
        }
    }
}
