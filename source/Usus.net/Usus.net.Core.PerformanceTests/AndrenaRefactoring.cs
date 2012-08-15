using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Usus.net.Core.PerformanceTests
{
    public class AndrenaRefactoring : FolderAnalysis
    {
        [TestMethod]
        public void AnalyzeVorherNachher()
        {
            Console.WriteLine("vorher");
            var vorher = AnalyzeAssembliesIn(Samples.Folder + @"andrena_refactoring\vorher");
            OutputAnalysisMetrics("vorher", vorher);
            Console.WriteLine("nachher");
            var nachher = AnalyzeInParallelAssembliesIn(Samples.Folder + @"andrena_refactoring\nachher");
            OutputAnalysisMetrics("nachher", nachher);
        }
    }
}