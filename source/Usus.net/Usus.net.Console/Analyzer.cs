using System.Linq;
using andrena.Usus.net.Core;
using andrena.Usus.net.Core.Hotspots;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.Console
{
    abstract class Analyzer
    {
        public void AnalyzeThisAssembly()
        {
            var metrics = Analyze.Me();
            OutputMetricsReport(metrics);
        }

        public void AnalyzeFile(string assemblyToAnalyze)
        {
            var metrics = Analyze.PortableExecutable(assemblyToAnalyze);
            OutputMetricsReport(metrics);
        }

        private void OutputMetricsReport(MetricsReport metrics)
        {
            foreach (var method in metrics.Methods)
                OutputMethodMetricsReport(method);

            OutputSeperator();
            OutputSeperator();
            OutputRatings(metrics.Rate());
            OutputHotspots(metrics.Hotspots());
        }

        private void OutputSeperator()
        {
            Output("---------------------------------------------------");
        }

        private void OutputMethodMetricsReport(MethodMetricsReport methodMetrics)
        {
            OutputSeperator();
            Output("Name:\t\t" + methodMetrics.Name);
            Output("Signature:\t" + methodMetrics.Signature);
            Output("Generated:\t" + methodMetrics.CompilerGenerated);
            Output("\tCyclomaticComplexity:\t" + methodMetrics.CyclomaticComplexity);
            Output("\tNumberOfStatements:\t" + methodMetrics.NumberOfStatements);
            Output("\tNumberOfRealLines:\t" + methodMetrics.NumberOfRealLines);
            Output("\tNumberOfLogicalLines:\t" + methodMetrics.NumberOfLogicalLines);
            Output("\tTypes:\t\t\t" + string.Join(", ", methodMetrics.TypeDependencies));
            Output("");
        }

        private void OutputRatings(RatedMetrics rated)
        {
            Output("Overall Metrics");
            Output("\tAverageRatedCyclomaticComplexity:\t" + rated.AverageRatedCyclomaticComplexity);
            Output("\tAverageRatedMethodLength:\t\t" + rated.AverageRatedMethodLength);
            Output("");
        }

        private void OutputHotspots(MetricsHotspots hotspots)
        {
            Output("Hotspots");
            Output("\tCyclomaticComplexity:\t" + string.Join(", ", hotspots.OfCyclomaticComplexity().Select(h => h.Signature)));
            Output("\tMethodLength:\t\t" + string.Join(", ", hotspots.OfMethodLength().Select(h => h.Signature)));
            Output("");
        }

        protected abstract void Output(string line);
    }
}
