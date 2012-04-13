using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UsusNetRule
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T1> SelectManyRecursive<T, R, T1>(this IEnumerable<T> enumerable, Func<T, IEnumerable<T1>> selector1, Func<R, IEnumerable<T1>> selector2) where R : class
        {
            return enumerable.SelectMany(t =>
            {
                if (t is R) return selector2(t as R);
                else return selector1(t);
            });
        }
    }
}
