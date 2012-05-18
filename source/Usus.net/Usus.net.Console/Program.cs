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
            MethodMetrics methodMetics = new MethodMetrics();
            methodMetics.Analyze(assemblyToAnalyze);
        }
    }
}
