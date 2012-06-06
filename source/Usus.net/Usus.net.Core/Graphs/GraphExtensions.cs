using System;
using System.Collections.Generic;

namespace andrena.Usus.net.Core.Graphs
{
    public static class GraphExtensions
    {
        public static Graph<T> ToGraph<T>(this IDictionary<T, IEnumerable<T>> graphDict) where T : class
        {
            return new Graph<T>(graphDict);
        }
    }
}
