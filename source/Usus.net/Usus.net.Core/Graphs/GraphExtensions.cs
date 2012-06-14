using System;
using System.Collections.Generic;

namespace andrena.Usus.net.Core.Graphs
{
    public static class GraphExtensions
    {
        public static MutableGraph<T> ToGraph<T>(this IDictionary<T, IEnumerable<T>> graphDict)
            where T : class
        {
            return new MutableGraph<T>(graphDict);
        }

        public static IGraph<T> Select<T, R>(this IGraph<R> graph, Func<R, T> vertexSelector)
            where T : class
            where R : class
        {
            return new GraphSurrogate<T, R>(graph, vertexSelector);
        }
    }
}
