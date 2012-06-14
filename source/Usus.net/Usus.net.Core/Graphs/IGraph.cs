using System;
using System.Collections.Generic;

namespace andrena.Usus.net.Core.Graphs
{
    public interface IGraph<T> where T : class
    {
        IEnumerable<T> Vertices { get; }
        IEnumerable<Tuple<T, T>> Edges { get; }
    }
}
