using System;
using System.Collections.Generic;
using System.Linq;
using QuickGraph;

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

        internal Graph(BidirectionalGraph<T, Edge<T>> graph)
        {
            this.graph = graph;
        }

        public void Reduce(T vertex, IEnumerable<T> vertices)
        {
            graph.MergeVertices(vertex, vertices);
        }

        public Graph<T> Reach(T start)
        {
            var reachGraph = start.ToNewGraph(PARALLEL_EDGES);
            graph.Dfs(start, e => reachGraph.AddVerticesAndEdge(e));
            return new Graph<T>(reachGraph);
        }

        public Graph<R> Cast<R>(Func<T, R> selector) where R : class
        {
            return graph.Clone(selector);
        }
    }
}
