using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Usus.net.Core.UnitTests.Factories;
using System;

namespace Usus.net.Core.UnitTests
{
    [TestClass]
    public class GraphReduceTests
    {
        [TestMethod]
        public void Reduce_Triangle_SingleEdge()
        {
            var graphDict = new Dictionary<string, IEnumerable<string>>();
            graphDict.Add("a", new List<string> { "b", "c" });
            graphDict.Add("b", new List<string> { "c" });
            graphDict.Add("c", new List<string> { });

            var reduced = graphDict.GetReduced("a", "b");
            Assert.IsTrue(reduced.ContainsAllVertices("a", "c"));
            Assert.IsTrue(reduced.ContainsAllVerticesNot("b"));
        }

        [TestMethod]
        public void Reduce_Line_SingleVertex()
        {
            var graphDict = new Dictionary<string, IEnumerable<string>>();
            graphDict.Add("a", new List<string> { "b" });
            graphDict.Add("b", new List<string> { });

            var reduced = graphDict.GetReduced("a", "b");
            Assert.IsTrue(reduced.ContainsAllVertices("a"));
            Assert.IsTrue(reduced.ContainsAllVerticesNot("b"));
        }

        [TestMethod]
        public void Reduce_Line_NoSelftEdge()
        {
            var graphDict = new Dictionary<string, IEnumerable<string>>();
            graphDict.Add("a", new List<string> { "b" });
            graphDict.Add("b", new List<string> { });

            var reduced = graphDict.GetReduced("a");
            Assert.IsTrue(reduced.ContainsAllEdgesNot(Tuple.Create("b", "b")));
        }
    }
}
