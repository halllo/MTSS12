using System;
using System.Collections.Generic;
using System.Linq;
using QuickGraph;
using QuickGraph.Algorithms.Search;

namespace andrena.Usus.net.Core.Graphs
{
    public class Graph<T> where T : class
    {
        AdjacencyGraph<T, Edge<T>> graph;

        public IEnumerable<T> Vertices { get { return graph.Vertices; } }

        public Graph(IDictionary<T, IEnumerable<T>> graphDict)
        {
            graph = graphDict.Keys.ToAdjacencyGraph(v => graphDict[v].Select(e => new Edge<T>(v, e)));
        }

        private Graph(AdjacencyGraph<T, Edge<T>> graph)
        {
            this.graph = graph;
        }

        public Graph<T> Reach(T start)
        {
            var reachGraph = new AdjacencyGraph<T, Edge<T>>(false);
            reachGraph.AddVertex(start);

            var dfs = new DepthFirstSearchAlgorithm<T, Edge<T>>(graph);
            dfs.StartVertex += v => { if (!v.Equals(start)) dfs.Abort(); };
            dfs.ExamineEdge += e => reachGraph.AddVerticesAndEdge(e);
            dfs.Compute(start);

            return new Graph<T>(reachGraph);
        }
    }
}
