using System;
using System.Collections.Generic;
using System.Linq;

namespace GetPermutation {

    public class Permutation {
        public IEnumerable<T[]> Enumerate<T>(IEnumerable<T> items) {
            if (items.Count() == 1) {
                yield return new T[] { items.First() };
                yield break;
            }
            foreach (var item in items) {
                var leftside = new T[] { item };
                var unused = items.Except(leftside);
                foreach (var rightside in Enumerate(unused)) {
                    yield return leftside.Concat(rightside).ToArray();
                }
            }
        }
    }

    public class Permutation1stVersion {
        
        public IEnumerable<T[]> Enumerate<T>(IEnumerable<T> items) {
            return _GetPermutations<T>(new List<T>(), items.ToList());
        }

        private IEnumerable<T[]> _GetPermutations<T>(IEnumerable<T> perm, IEnumerable<T> items) {
            if (items.Count() == 0) {
                yield return perm.ToArray();
            } else {
                foreach (var item in items) {
                    var result = _GetPermutations<T>(perm.Concat(new T[] { item }),
                                                        items.Where(x => x.Equals(item) == false)
                                    );
                    foreach (var xs in result)
                        yield return xs.ToArray();
                }
            }
        }
    }
}
