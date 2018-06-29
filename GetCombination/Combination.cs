using System;
using System.Collections.Generic;
using System.Linq;

namespace GetCombination {
    public static class Combination {
        public static IEnumerable<T[]> Enumerate<T>(IEnumerable<T> items, int k, bool withRepetition) {
            if (k == 1) {
                foreach (var item in items)
                    yield return new T[] { item };
                yield break;
            }
            foreach (var item in items) {
                var leftside = new T[] { item };

                // item よりも前のものを除く （順列と組み合わせの違い)
                // 重複を許さないので、unusedから item そのものも取り除く
                var unused = withRepetition 
                            ? items 
                            : items.SkipWhile(e => !e.Equals(item)).Skip(1).ToList();

                foreach (var rightside in Enumerate(unused, k - 1, withRepetition)) {
                    yield return leftside.Concat(rightside).ToArray();
                }
            }
        }
    }
}
