using System.IO;
using System.Linq;
using andrena.Usus.net.Core;
using andrena.Usus.net.Core.Reports;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Usus.net.Core.PerformanceTests
{
    [TestClass]
    public class PdbIssueTests
    {
        [TestMethod]
        public void Analyze_NoChanges_NoDifferencesInMetrics()
        {
            var build1 = Analyze.PortableExecutables(In("../../../Usus.net.Core.PerformanceTests/PdbIssue/build1"));
            var build2 = Analyze.PortableExecutables(In("../../../Usus.net.Core.PerformanceTests/PdbIssue/build2"));
            var buildDifferences = Changes.Of(build2).ComparedTo(build1);
            Assert.IsFalse(buildDifferences.Any());
        }

        private string[] In(string path)
        {
            return Directory.EnumerateFiles(path, "*.dll").ToArray();
        }
    }
}