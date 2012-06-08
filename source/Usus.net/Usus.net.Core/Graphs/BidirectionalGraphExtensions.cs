using System.Collections.Generic;
using System.Linq;
using QuickGraph;

namespace andrena.Usus.net.Core.Graphs
{
    internal static class BidirectionalGraphExtensions
    {
        public static BidirectionalGraph<T, Edge<T>> ToNewGraph<T>(this T start, bool parallelEdges)
        {
            var graph = new BidirectionalGraph<T, Edge<T>>(parallelEdges);
            graph.AddVertex(start);
            return graph;
        }

        public static void MergeTogether<T>(this BidirectionalGraph<T, Edge<T>> graph, IEnumerable<T> vertices)
        {
            var reducedVertex = vertices.FirstOrDefault();
            if (reducedVertex != null) graph.MergeVerticesTo(reducedVertex, vertices.Skip(1));
        }

        public static void MergeVerticesTo<T>(this BidirectionalGraph<T, Edge<T>> reducedGraph, T reducedVertex, IEnumerable<T> otherVertices)
        {
            foreach (var vertex in otherVertices)
            {
                reducedGraph.AddEdge(new Edge<T>(reducedVertex, vertex));
                reducedGraph.MergeVertex(vertex, (s, t) => new Edge<T>(s, t));
            }
        }
    }
}
