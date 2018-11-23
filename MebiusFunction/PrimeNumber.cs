using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MebiusFunction {
    public static class PrimeNumber {

        public static IEnumerable<int> Enumerate() {
            // 2,3は既知の素数とする
            var primes = new List<int>() { 2, 3 };
            foreach (var p in primes)
                yield return p;

            // 4以上の整数から素数を列挙する。int.MaxValueを超えたときには対処していない
            int ix = 0;
            while (true) {
                int prime1st = primes[ix];
                int prime2nd = primes[++ix];
                // ふるい用の配列の下限、上限を求め、配列を確保する。
                var lower = prime1st * prime1st;
                var upper = prime2nd * prime2nd - 1;
                // ふるいは、[4:8], [9:24], [25:48], [49:120]... と変化する。
                // []内の数値は、配列の下限と上限
                var sieve = new BoundedBoolArray(lower, upper);

                // 求まっている素数を使い、ふるいに掛ける 
                foreach (var prime in primes.Take(ix)) {
                    var start = (int)Math.Ceiling((double)lower / prime) * prime;
                    for (int index = start; index <= upper; index += prime)
                        sieve[index] = true;
                }

                // ふるいに掛けられて残った値が素数。これを列挙する。
                // 併せて、求まった素数は、primesリストに記憶していく。
                // この素数が次にふるいに掛ける際に利用される。
                for (int i = lower; i <= upper; i++) {
                    if (sieve[i] == false) {
                        primes.Add(i);
                        yield return i;
                    }
                }
            }
        }
    }

    // 下限、上限が指定できるbool型配列
    class BoundedBoolArray {
        private BitArray _array;
        private int _lower;

        public BoundedBoolArray(int lower, int upper) {
            _array = new BitArray(upper - lower + 1);
            _lower = lower;
        }

        public bool this[int index] {
            get {
                return _array[index - _lower];
            }
            set {
                _array[index - _lower] = value;
            }
        }
    }
}
