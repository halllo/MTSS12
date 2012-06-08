using System;
using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.Graphs;

namespace Usus.net.Core.UnitTests.Factories
{
    public static class CreateGraph
    {
        public static Graph<string> GetReach(this Dictionary<string, IEnumerable<string>> graphDict, string start)
        {
            var graph = graphDict.ToGraph();
            return graph.Reach(start);
        }

        public static Graph<string> GetReduced(this Dictionary<string, IEnumerable<string>> graphDict, params string[] toReduce)
        {
            var graph = graphDict.ToGraph();
            return graph.Reduce(toReduce);
        }

        public static bool ContainsAllEdges(this Graph<string> sequence, params Tuple<string, string>[] contains)
        {
            return contains.All(c => sequence.Edges.Contains(c));
        }

        public static bool ContainsAllEdgesNot(this Graph<string> sequence, params Tuple<string, string>[] contains)
        {
            return contains.All(c => !sequence.Edges.Contains(c));
        }

        public static bool ContainsAllVertices(this Graph<string> sequence, params string[] contains)
        {
            return contains.All(c => sequence.Vertices.Contains(c));
        }

        public static bool ContainsAllVerticesNot(this Graph<string> sequence, params string[] contains)
        {
            return contains.All(c => !sequence.Vertices.Contains(c));
        }
    }
}
