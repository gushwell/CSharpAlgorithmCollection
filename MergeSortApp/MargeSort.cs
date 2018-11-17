using System;
using System.Linq;
using System.Collections.Generic;

namespace MergeSortApp {
    static class MargeSort {
        public static IEnumerable<T> Sort<T>(IEnumerable<T> items, Comparison<T> compare) {
            if (items.Count() > 1) {
                int m = items.Count() / 2;
                var a1 = items.Take(m).ToArray();
                var a2 = items.Skip(m).ToArray();
                return Merge(Sort(a1, compare), Sort(a2, compare), compare);
            }
            return items;
        }

        // 非再帰版　Mergeメソッド
        private static IEnumerable<T> Merge<T>(IEnumerable<T> a1, IEnumerable<T> a2, Comparison<T> compare) {
            var ite1 = a1.GetEnumerator();
            var ite2 = a2.GetEnumerator();
            var exists1 = ite1.MoveNext();
            var exists2 = ite2.MoveNext();
            while (exists1 == true && exists2 == true) {
                T x1 = ite1.Current;
                T x2 = ite2.Current;
                if (compare(x1, x2) < 0) {
                    yield return x1;
                    exists1 = ite1.MoveNext();
                } else {
                    yield return x2;
                    exists2 = ite2.MoveNext();
                }
            }
            while (exists1) {
                yield return ite1.Current;
                exists1 = ite1.MoveNext();
            }
            while (exists2) {
                yield return ite2.Current;
                exists2 = ite2.MoveNext();
            }
        }
    }
}
