using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Usus.net.Core.PerformanceTests
{
    [TestClass]
    public class AndrenaRefactoring : FolderAnalysis
    {
        [TestMethod]
        public void AnalyzeVorherNachher()
        {
            Console.WriteLine("vorher");
            var vorher = AnalyzeAssembliesIn(Samples.AndrenaFactory + "vorher");
            OutputAnalysisMetrics("vorher", vorher);
            Console.WriteLine("nachher");
            var nachher = AnalyzeInParallelAssembliesIn(Samples.AndrenaFactory + "nachher");
            OutputAnalysisMetrics("nachher", nachher);
        }
    }
}