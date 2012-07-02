using System;
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
    }
}
