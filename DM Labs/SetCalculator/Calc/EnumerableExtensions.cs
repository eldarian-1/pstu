using System;
using System.Linq;
using System.Collections.Generic;

namespace Calc
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> MyExcept<T>(this IEnumerable<T> left, IEnumerable<T> right)
        {
            return left.OperationImpl(right, (a, b) => a - b);
        }

        public static IEnumerable<T> MyUnite<T>(this IEnumerable<T> left, IEnumerable<T> right)
        {
            return left.Concat(right);
        }

        public static IEnumerable<T> MyIntersect<T>(this IEnumerable<T> left, IEnumerable<T> right)
        {
            return left.OperationImpl(right, (a, b) => Math.Min(a, b));
        }

        public static IEnumerable<T> MySymmetricDifference<T>(this IEnumerable<T> left, IEnumerable<T> right)
        {
            return left.MyExcept(right).MyUnite(right.MyExcept(left));
        }

        private static IEnumerable<T> OperationImpl<T>(this IEnumerable<T> left, IEnumerable<T> right,
            Func<int, int, int> getCount)
        {
            var leftGroups = left.ToLookup(x => x);
            var rightGroups = right.ToLookup(x => x);

            foreach (var element in leftGroups)
            {
                var other = rightGroups[element.Key];

                int count = getCount(element.Count(), other.Count());

                for (int i = 0; i < count; i++)
                    yield return element.Key;
            }
        }
    }
}