using System;
using System.Collections.Generic;
using System.Linq;

namespace andrena.Usus.net.Core.Helper
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<R> SelectList<T, R>(this IEnumerable<T> list, Func<T, R> selector)
        {
            return list.Select(selector).ToList();
        }
    }
}
