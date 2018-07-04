using System;
using System.Collections.Generic;
using System.Linq;

namespace GetDerangements {
    public static class Permutation {
        public static IEnumerable<T[]> Enumerate<T>(IEnumerable<T> items, int k, bool withRepetition) {
            if (k == 1) {
                foreach (var item in items) {
                    yield return new T[] { item };
                }
                yield break;
            }
            foreach (var item in items) {
                var leftside = new T[] { item };
                var unused = withRepetition ? items : items.Except(leftside);
                foreach (var rightside in Enumerate(unused, k - 1, withRepetition)) {
                    yield return leftside.Concat(rightside).ToArray();
                }
            }
        }
    }
}
