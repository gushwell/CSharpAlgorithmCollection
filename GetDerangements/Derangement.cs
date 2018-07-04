using System;
using System.Collections.Generic;
using System.Linq;

namespace GetDerangements {
    public static class Derangement {
        // 攪乱順列（完全順列ともいう）を列挙する
        public static IEnumerable<T[]> Enumerate<T>(IEnumerable<T> items) {
            var original = items.ToArray();
            foreach (var element in Permutation.Enumerate(items, items.Count(), false)) {
                bool isComplete = element.Zip(original, (a, b) => a.Equals(b))
                                         .All(x => x == false);
                if (isComplete)
                    yield return element;
            }
        }
    }
}
