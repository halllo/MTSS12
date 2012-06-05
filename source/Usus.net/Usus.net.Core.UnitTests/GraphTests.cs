using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Usus.net.Core.UnitTests.Factories;

namespace Usus.net.Core.UnitTests
{
    [TestClass]
    public class GraphTests
    {
        [TestMethod]
        public void Reach_Circle_All()
        {
            var graphDict = new Dictionary<string, IEnumerable<string>>();
            graphDict.Add("a", new List<string> { "b", "c" });
            graphDict.Add("b", new List<string> { "d" });
            graphDict.Add("c", new List<string> { "d" });
            graphDict.Add("d", new List<string> { "a" });

            var reach = CreateGraph.Reach(graphDict, "a");
            Assert.IsTrue(reach.ContainsAll("a", "b", "c", "d"));
        }

        [TestMethod]
        public void Reach_LineFromLast_OnlyStarting()
        {
            var graphDict = new Dictionary<string, IEnumerable<string>>();
            graphDict.Add("a", new List<string> { "b" });
            graphDict.Add("b", new List<string> { "c" });
            graphDict.Add("c", new List<string> { "d" });
            graphDict.Add("d", new List<string> { });

            var reach = CreateGraph.Reach(graphDict, "d");
            Assert.IsTrue(reach.ContainsAllNot("a", "b", "c"));
            Assert.IsTrue(reach.ContainsAll("d"));
        }

        [TestMethod]
        public void Reach_LineFromSecondLast_LastTwo()
        {
            var graphDict = new Dictionary<string, IEnumerable<string>>();
            graphDict.Add("a", new List<string> { "b" });
            graphDict.Add("b", new List<string> { "c" });
            graphDict.Add("c", new List<string> { "d" });
            graphDict.Add("d", new List<string> { });

            var reach = CreateGraph.Reach(graphDict, "c");
            Assert.IsTrue(reach.ContainsAllNot("a", "b"));
            Assert.IsTrue(reach.ContainsAll("c", "d"));
        }
    }
}
