using System;
using System.Collections.Generic;
using System.Linq;

namespace andrena.Usus.net.Core.Helper
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Return<T>(this T start)
        {
            yield return start;
        }
     
        public static IEnumerable<R> ToList<T, R>(this IEnumerable<T> sequence, Func<T, R> selector)
        {
            return sequence.Select(selector).ToList();
        }

        public static double AverageAny<T>(this IEnumerable<T> sequence, Func<T, double> selector)
        {
            return sequence.Any() ? sequence.Average(selector) : 0.0;
        }
    }
}
