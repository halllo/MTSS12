using andrena.Usus.net.Core.Hotspots;
using andrena.Usus.net.Core.Reports;

namespace Usus.net.Core.UnitTests.Factories.Metrics
{
    public static class CreateRated
    {
        public static double CyclomaticComplexity(int cc)
        {
            var metrics = new MethodMetricsReport { CyclomaticComplexity = cc };
            metrics.CommonKnowledge = new CommonReportKnowledge { NumberOfClasses = 0 };
            return metrics.Rate().RatedCyclomaticComplexity;
        }

        public static double MethodLength(int ml)
        {
            var metrics = new MethodMetricsReport { NumberOfLogicalLines = ml };
            metrics.CommonKnowledge = new CommonReportKnowledge { NumberOfClasses = 0 };
            return metrics.Rate().RatedMethodLength;
        }

        public static double MethodLength(int numberOfLogicalLines, int numberOfStatements)
        {
            var metrics = new MethodMetricsReport
            {
                NumberOfLogicalLines = numberOfLogicalLines,
                NumberOfStatements = numberOfStatements
            };
            metrics.CommonKnowledge = new CommonReportKnowledge { NumberOfClasses = 0 };
            return metrics.Rate().RatedMethodLength;
        }

        public static double ClassSize(int cs)
        {
            var metrics = new TypeMetricsReport { NumberOfMethods = cs };
            metrics.CommonKnowledge = new CommonReportKnowledge { NumberOfClasses = 0 };
            return metrics.Rate().RatedClassSize;
        }

        public static double NumberOfNonStaticPublicFields(int nspfs)
        {
            var metrics = new TypeMetricsReport { NumberOfNonStaticPublicFields = nspfs };
            metrics.CommonKnowledge = new CommonReportKnowledge { NumberOfClasses = 0 };
            return metrics.Rate().RatedNumberOfNonStaticPublicFields;
        }
    }
}
