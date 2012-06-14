using System;
using System.Collections.Generic;
using System.Linq;

namespace andrena.Usus.net.Core.Graphs
{
    internal class GraphSurrogate<T, R> : IGraph<T>
        where T : class
        where R : class
    {
        IGraph<R> graph;
        Func<R, T> vertexSelector;

        internal GraphSurrogate(IGraph<R> graph, Func<R, T> vertexSelector)
        {
            this.graph = graph;
            this.vertexSelector = vertexSelector;
        }

        public IEnumerable<T> Vertices
        {
            get { return graph.Vertices.Select(vertexSelector); }
        }

        public IEnumerable<Tuple<T, T>> Edges
        {
            get { return graph.Edges.Select(e => Tuple.Create(vertexSelector(e.Item1), vertexSelector(e.Item2))); }
        }
    }
}
