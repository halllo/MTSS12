using System;
using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.AssemblyNavigation;
using Microsoft.Cci;
using andrena.Usus.net.Core.Metrics.Methods;
using andrena.Usus.net.Core.Metrics;

namespace andrena.Usus.net.Core
{
    public class MetricsEngine : MetricGathering
    {
        protected override void AnalyzeType(INamedTypeDefinition type, PdbReader pdb)
        {
            Console.WriteLine("Type: " + type.Name);
            Console.WriteLine();
        }

        protected override MethodMetricsReport AnalyzeMethod(IMethodDefinition method, PdbReader pdb)
        {
            return new MethodMetricsReport
            {
                MethodName = method.Name.ToString(),
                CyclomaticComplexity = CyclomaticComplexity.Of(method),
                MethodLength = MethodLength.Of(method),
                MethodLengthWithSymbols = MethodLength.WithSymbols(method, pdb),
                TypeDependencies = TypeDependencies.Of(method)
            };
        }
    }
}