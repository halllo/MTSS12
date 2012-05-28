using System;
using andrena.Usus.net.Core.AssemblyNavigation;
using andrena.Usus.net.Core.Metrics.Methods;
using andrena.Usus.net.Core.Reports;
using Microsoft.Cci;

namespace andrena.Usus.net.Core.Metrics
{
    internal class MetricsCollector : AssemblyVisitor
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
                Name = method.Name(),
                Signature = method.Signature(),
                CyclomaticComplexity = CyclomaticComplexity.Of(method),
                NumberOfStatements = NumberOfStatements.Of(method),
                NumberOfRealLines = NumberOfRealLines.Of(method, pdb),
                NumberOfLogicalLines = NumberOfLogicalLines.Of(method, pdb),
                TypeDependencies = TypeDependencies.Of(method)
            };
        }
    }
}