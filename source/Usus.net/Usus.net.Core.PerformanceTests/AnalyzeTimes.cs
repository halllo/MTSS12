using System;
using andrena.Usus.net.Core.Reports;

namespace Usus.net.Core.PerformanceTests
{
    public class AnalyzeTimes
    {
        public TimeSpan PostProcessingTime { get; private set; }
        public TimeSpan AnalysisTime { get; private set; }
        public TimeSpan CompleteTime { get; private set; }

        public AnalyzeTimes(MetricsReport metrics)
        {
            var whenCreated = metrics.Remember.WhenCreated;
            var whenAssemblyAnalysisDone = metrics.Remember.WhenAssemblyAnalysisDone;
            var whenPostProcessingDone = metrics.Remember.WhenPostProcessingDone;
            AnalysisTime = whenAssemblyAnalysisDone - whenCreated;
            PostProcessingTime = whenPostProcessingDone - whenAssemblyAnalysisDone;
            CompleteTime = AnalysisTime + PostProcessingTime;    
        }
    }
}