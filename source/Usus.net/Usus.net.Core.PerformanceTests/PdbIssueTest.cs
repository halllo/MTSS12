using System.Linq;
using andrena.Usus.net.Core.Reports;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Usus.net.Core.PerformanceTests
{
    [TestClass]
    public class PdbIssueTest : FolderAnalysis
    {
        //[TestMethod]
        //public void Analyze_NoChanges_NoDifferencesInMetrics()
        //{
        //    var build1 = AnalyzeAssembliesIn(Samples.Folder + "PdbIssue/build1");
        //    var build2 = AnalyzeAssembliesIn(Samples.Folder + "PdbIssue/build2");
        //    var buildDifferences = Changes.Of(build2).ComparedTo(build1);
        //    Assert.IsFalse(buildDifferences.Any());
        //}

        //[TestMethod]
        //public void AnalyzeParallel_NoChanges_NoDifferencesInMetrics()
        //{
        //    var build1 = AnalyzeInParallelAssembliesIn(Samples.Folder + "PdbIssue/build1");
        //    var build2 = AnalyzeInParallelAssembliesIn(Samples.Folder + "PdbIssue/build2");
        //    var buildDifferences = Changes.Of(build2).ComparedTo(build1);
        //    Assert.IsFalse(buildDifferences.Any());
        //}
    }
}