using System;
using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core;

namespace andrena.Usus.net.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            AnalyzeFile(@"C:\Users\mnaujoks\Documents\Visual Studio 2010\Projects\ConsoleApplication2\ConsoleApplication1\bin\Debug\ConsoleApplication1.exe");
            System.Console.ReadLine();
        }

        private static void AnalyzeFile(string assemblyToAnalyze)
        {
            MetricsEngine metrics = new MetricsEngine();
            metrics.Analyze(assemblyToAnalyze);
            
            foreach (var method in metrics.Report.Methods)
            {
                System.Console.WriteLine(method.MethodName);
                System.Console.WriteLine("\t" + method.CyclomaticComplexity);
                System.Console.WriteLine("\t" + method.MethodLengthWithSymbols);
                System.Console.WriteLine("\t" + method.MethodLength);
                System.Console.WriteLine("\t" + string.Join(", ", method.TypeDependencies));
                System.Console.WriteLine();
            }
        }
    }
}
