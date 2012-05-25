using andrena.Usus.net.Core;
using andrena.Usus.net.Core.Metrics;
using andrena.Usus.net.Core.Verification;
using andrena.Usus.net.Core.Hotspots;

namespace andrena.Usus.net.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //AnalyzeThisAssembly();
            AnalyzeFile(@"C:\Users\mnaujoks\Documents\Visual Studio 2010\Projects\ConsoleApplication2\ConsoleApplication1\bin\Debug\ConsoleApplication1.exe");
            
            System.Console.ReadLine();
        }

        private static void AnalyzeThisAssembly()
        {
            MetricsCollector metrics = new MetricsCollector();
            metrics.AnalyzeMe();
            OutputMethodMetricsReport(metrics.Report.For(() => AnalyzeFile("")));
        }

        private static void AnalyzeFile(string assemblyToAnalyze)
        {
            MetricsCollector metrics = new MetricsCollector();
            metrics.Analyze(assemblyToAnalyze);

            foreach (var method in metrics.Report.Methods)
                OutputMethodMetricsReport(method);

            OutputRatings(metrics.Report.Rate());
        }

        private static void OutputMethodMetricsReport(MethodMetricsReport methodMetrics)
        {
            Output(methodMetrics.Name);
            Output("\tSignature:\t\t" + methodMetrics.Signature);
            Output("\tCyclomaticComplexity:\t" + methodMetrics.CyclomaticComplexity);
            Output("\tNumberOfStatements:\t" + methodMetrics.NumberOfStatements);
            Output("\tNumberOfRealLines:\t" + methodMetrics.NumberOfRealLines);
            Output("\tNumberOfLogicalLines:\t" + methodMetrics.NumberOfLogicalLines);
            Output("\tTypes:\t\t\t" + string.Join(", ", methodMetrics.TypeDependencies));
            Output("");
        }

        private static void OutputRatings(RatedMetrics rated)
        {
            Output("Overall Metrics");
            Output("\tAverageRatedCyclomaticComplexity:\t" + rated.AverageRatedCyclomaticComplexity);
            Output("\tAverageRatedMethodLength:\t\t" + rated.AverageRatedMethodLength);
        }
        
        private static void Output(string line)
        {
            System.Console.WriteLine(line);
        }
    }
}
