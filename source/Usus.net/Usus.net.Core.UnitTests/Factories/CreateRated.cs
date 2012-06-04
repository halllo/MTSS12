using andrena.Usus.net.Core.Hotspots;
using andrena.Usus.net.Core.Reports;

namespace Usus.net.Core.UnitTests.Factories
{
    public static class CreateRated
    {
        public static double CyclomaticComplexity(int cc)
        {
            var metrics = new MethodMetricsReport { CyclomaticComplexity = cc };
            return metrics.Rate().RatedCyclomaticComplexity;
        }

        public static double MethodLength(int ml)
        {
            var metrics = new MethodMetricsReport { NumberOfLogicalLines = ml };
            return metrics.Rate().RatedMethodLength;
        }

        public static double MethodLength(int numberOfLogicalLines, int numberOfStatements)
        {
            var metrics = new MethodMetricsReport
            {
                NumberOfLogicalLines = numberOfLogicalLines,
                NumberOfStatements = numberOfStatements
            };
            return metrics.Rate().RatedMethodLength;
        }

        public static double ClassSize(int cs)
        {
            var metrics = new TypeMetricsReport { NumberOfMethods = cs };
            return metrics.Rate().RatedClassSize;
        }
    }
}
