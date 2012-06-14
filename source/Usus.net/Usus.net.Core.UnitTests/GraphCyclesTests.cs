using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Usus.net.Core.UnitTests.Factories;

namespace Usus.net.Core.UnitTests
{
    [TestClass]
    public class GraphCyclesTests
    {
        [TestMethod]
        public void Cylces_StraightGraph_None()
        {
            var graphDict = new Dictionary<string, IEnumerable<string>>();
            graphDict.Add("a", new List<string> { "b", "c" });
            graphDict.Add("b", new List<string> { "c" });
            graphDict.Add("c", new List<string> { });

            var cycles = graphDict.GetCycles();
            Assert.IsFalse(cycles.Any());
        }

        [TestMethod]
        public void Cylces_TwoVerticesInCycle_OneWithTwo()
        {
            var graphDict = new Dictionary<string, IEnumerable<string>>();
            graphDict.Add("a", new List<string> { "b" });
            graphDict.Add("b", new List<string> { "a" });

            var cycles = graphDict.GetCycles();
            Assert.IsTrue(cycles.Count() == 1 
                && cycles.First().Count() == 2);
        }

        [TestMethod]
        public void Cylces_FourVerticesTwoCycles_TwoWithTwo()
        {
            var graphDict = new Dictionary<string, IEnumerable<string>>();
            graphDict.Add("a", new List<string> { "b", "c" });
            graphDict.Add("b", new List<string> { "a" });
            graphDict.Add("c", new List<string> { "d" });
            graphDict.Add("d", new List<string> { "c" });

            var cycles = graphDict.GetCycles();
            Assert.IsTrue(cycles.Count() == 2
                && cycles.First().Count() == 2
                && cycles.Last().Count() == 2);
        }
    }
}
