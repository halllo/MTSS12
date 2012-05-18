using System;
using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.AssemblyNavigation;
using Microsoft.Cci;
using andrena.Usus.net.Core.Metrics.Methods;

namespace andrena.Usus.net.Core
{
    public class MethodMetrics : MetricGathering
    {
        protected override void AnalyzeType(INamedTypeDefinition type, PdbReader pdb)
        {
            Console.WriteLine("Type: " + type.Name);
            Console.WriteLine();
        }

        protected override void AnalyzeMethod(IMethodDefinition method, PdbReader pdb)
        {
            Console.WriteLine("\tMethod: " + method.Name);
            Console.WriteLine("\t\tCyclomaticComplexity: " + CyclomaticComplexity.Of(method));
            Console.WriteLine("\t\tMethodLength: " + MethodLength.Of(method));
            Console.WriteLine("\t\tMethodLengthWithSymbols: " + MethodLength.WithSymbols(method, pdb));
            Console.WriteLine("\t\tTypeDependencies: " + string.Join(",", TypeDependencies.Of(method)));
            Console.WriteLine();
        }
    }
}