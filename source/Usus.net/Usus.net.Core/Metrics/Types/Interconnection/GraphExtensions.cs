using System;
using System.Collections.Generic;

namespace andrena.Usus.net.Core.Metrics.Types.Interconnection
{
    public static class GraphExtensions
    {
        public static Graph<T> ToGraph<T>(this IDictionary<T, IEnumerable<T>> graphDict) where T : IComparable
        {
            return new Graph<T>(graphDict);
        }
    }
}
