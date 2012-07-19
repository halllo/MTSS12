using System;
using System.Linq;
using andrena.Usus.net.Core.Math;
using andrena.Usus.net.Core.Reports;
using Usus.net.Core.UnitTests.Factories.Metrics;

namespace Usus.net.Core.UnitTests.Factories
{
    public static class CreateHistogram
    {
        public static IHistogram ForMethods(Func<MethodMetricsReport, int> selector, params MethodMetricsReport[] methods)
        {
            var report = Create.MetricsReport(methods);
            return report.MethodHistogram(selector);
        }

        public static IHistogram ForTypes(Func<TypeMetricsReport, int> selector, params TypeMetricsReport[] methods)
        {
            var report = Create.MetricsReport(methods);
            return report.TypeHistogram(selector);
        }

        public static IHistogram ForMethodLengths(params int[] methodLengths)
        {
            return ForMethods(m => m.MethodLength, methodLengths.Select(m => MethodReport(m, 1)).ToArray());
        }

        public static IHistogram ForPublicFields(params int[] publicFieldsLengths)
        {
            return ForTypes(m => m.NumberOfNonStaticPublicFields, publicFieldsLengths.Select(m => TypeReport(m)).ToArray());
        }

        private static MethodMetricsReport MethodReport(int methodLength, int cyclomaticComplexity)
        {
            return new MethodMetricsReport
            {
                CyclomaticComplexity = cyclomaticComplexity,
                NumberOfLogicalLines = methodLength
            };
        }

        private static TypeMetricsReport TypeReport(int publicfields)
        {
            return new TypeMetricsReport
            {
                FullName = Create.RandomName(),
                NumberOfNonStaticPublicFields = publicfields
            };
        }
    }
}
