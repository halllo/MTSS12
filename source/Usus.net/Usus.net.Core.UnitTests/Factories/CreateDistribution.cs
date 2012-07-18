using System;
using System.Linq;
using andrena.Usus.net.Core.Math;
using andrena.Usus.net.Core.Reports;
using Usus.net.Core.UnitTests.Factories.Metrics;

namespace Usus.net.Core.UnitTests.Factories
{
    public static class CreateDistribution
    {
        public static IHistogram For(Func<MethodMetricsReport, int> selector, params MethodMetricsReport[] methods)
        {
            var report = Create.MetricsReport(methods);
            return report.MethodDistribution(selector);
        }
        
        public static IHistogram ForMethodLengths(params int[] methodLengths)
        {
            return For(m => m.MethodLength, methodLengths.Select(m => Report(m, 1)).ToArray());
        }

        public static MethodMetricsReport Report(int methodLength, int cyclomaticComplexity)
        {
            return new MethodMetricsReport
            {
                CyclomaticComplexity = cyclomaticComplexity,
                NumberOfLogicalLines = methodLength
            };
        }
    }
}
