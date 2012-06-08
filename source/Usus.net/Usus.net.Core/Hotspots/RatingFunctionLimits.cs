using System;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.Core.Hotspots
{
    public class RatingFunctionLimits
    {
        public Func<CommonReportKnowledge, int> CyclomaticComplexity { get; set; }
        public Func<CommonReportKnowledge, int> MethodLength { get; set; }
        public Func<CommonReportKnowledge, int> ClassSize { get; set; }
        public Func<CommonReportKnowledge, int> NumberOfNonStaticPublicFields { get; set; }
        public Func<CommonReportKnowledge, int> CumulativeComponentDependency { get; set; }

        public RatingFunctionLimits()
        {
            CyclomaticComplexity = cn => 4;
            MethodLength = cn => 9;
            ClassSize = cn => 12;
            NumberOfNonStaticPublicFields = cn => 0;
            CumulativeComponentDependency = cn => (int)(cn.NumberOfClasses * (1.5 / Math.Pow(2, (Math.Log(cn.NumberOfClasses) / Math.Log(5)))));
        }
    }
}
