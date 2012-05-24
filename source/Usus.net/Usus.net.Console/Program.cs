using System;
using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core;
using andrena.Usus.net.Core.Metrics;

namespace andrena.Usus.net.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            AnalyzeFile(@"C:\Users\mnaujoks\Documents\Visual Studio 2010\Projects\ConsoleApplication2\ConsoleApplication1\bin\Debug\ConsoleApplication1.exe");
            //AnalyzeFile(System.Reflection.Assembly.GetExecutingAssembly().Location);
            System.Console.ReadLine();
        }

        private static void AnalyzeFile(string assemblyToAnalyze)
        {
            MetricsCollector metrics = new MetricsCollector();
            metrics.Analyze(assemblyToAnalyze);

            //var thisMetrics = metrics.Report.For(() => AnalyzeFile(""));
            //OutputMethodMetricsReport(thisMetrics);

            foreach (var method in metrics.Report.Methods)
                OutputMethodMetricsReport(method);
        }

        private static void OutputMethodMetricsReport(MethodMetricsReport methodMetrics)
        {
            System.Console.WriteLine(methodMetrics.Name);
            System.Console.WriteLine("\tcc: " + methodMetrics.CyclomaticComplexity);
            System.Console.WriteLine("\tns: " + methodMetrics.NumberOfStatements);
            System.Console.WriteLine("\tml: " + methodMetrics.NumberOfRealLines);
            System.Console.WriteLine("\tml: " + methodMetrics.NumberOfLogicalLines);
            System.Console.WriteLine("\ttd: " + string.Join(", ", methodMetrics.TypeDependencies));
            System.Console.WriteLine();
        }
    }
}
