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
            reducedGraph.MergeTogether(vertices);
            return new Graph<T>(reducedGraph);
        }

        public Graph<T> Reach(T start)
        {
            var reachGraph = start.ToNewGraph(PARALLEL_EDGES);
            Reach(start, e => reachGraph.AddVerticesAndEdge(e));
            return new Graph<T>(reachGraph);
        }

        private void Reach(T start, Action<Edge<T>> foundEdge)
        {
            var dfs = new DepthFirstSearchAlgorithm<T, Edge<T>>(graph);
            dfs.StartVertex += v => { if (!v.Equals(start)) dfs.Abort(); };
            dfs.ExamineEdge += e => foundEdge(e);
            dfs.Compute(start);
        }
    }
}
