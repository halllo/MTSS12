using System;
using System.Collections.Generic;
using System.Linq;
using QuickGraph;
using QuickGraph.Algorithms.Search;

namespace andrena.Usus.net.Core.Graphs
{
    public class Graph<T> where T : class
    {
        BidirectionalGraph<T, Edge<T>> graph;
        const bool PARALLEL_EDGES = false;

        public IEnumerable<T> Vertices { get { return graph.Vertices; } }
        public IEnumerable<Tuple<T, T>> Edges { get { return graph.Edges.Select(e => Tuple.Create(e.Source, e.Target)); } }

        public Graph(IDictionary<T, IEnumerable<T>> graphDict)
        {
            graph = graphDict.Keys.ToBidirectionalGraph(v => graphDict[v].Select(e => new Edge<T>(v, e)), PARALLEL_EDGES);
        }

        private Graph(BidirectionalGraph<T, Edge<T>> graph)
        {
            this.graph = graph;
        }

        public Graph<T> Reduce(params T[] vertices)
        {
            var reducedGraph = graph.Clone();
            foreach (var vertex in vertices.Skip(1))
                reducedGraph.MergeVertex(vertex, (s, t) => new Edge<T>(s, t));
            return new Graph<T>(reducedGraph);
        }

        public Graph<T> Reach(T start)
        {
            var reachGraph = NewEmptyGraph(start);
            Search(start, e => reachGraph.AddVerticesAndEdge(e));
            return new Graph<T>(reachGraph);
        }

        private static BidirectionalGraph<T, Edge<T>> NewEmptyGraph(T start)
        {
            var reachGraph = new BidirectionalGraph<T, Edge<T>>(PARALLEL_EDGES);
            reachGraph.AddVertex(start);
            return reachGraph;
        }

        private void Search(T start, Action<Edge<T>> foundEdge)
        {
            var dfs = new DepthFirstSearchAlgorithm<T, Edge<T>>(graph);
            dfs.StartVertex += v => { if (!v.Equals(start)) dfs.Abort(); };
            dfs.ExamineEdge += e => foundEdge(e);
            dfs.Compute(start);
        }
    }
}
