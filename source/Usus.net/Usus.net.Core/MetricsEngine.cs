using System;
using andrena.Usus.net.Core.AssemblyNavigation;
using andrena.Usus.net.Core.Metrics;
using andrena.Usus.net.Core.Metrics.Methods;
using Microsoft.Cci;

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
                Name = method.Name.ToString(),
                Signature = method.ToString(),
                CyclomaticComplexity = CyclomaticComplexity.Of(method),
                NumberOfStatements = NumberOfStatements.Of(method),
                NumberOfRealLines = MethodLength.RealLinesOf(method, pdb),
                NumberOfLogicalLines = MethodLength.LogicalLinesOf(method, pdb),
                TypeDependencies = TypeDependencies.Of(method)
            };
        }
    }
}