using System;
using System.Collections.Generic;

namespace EnumerateKaprekarNumber {
    public class KaprekarValue {
        public long Number { get; set; }
        public int Part1 { get; set; }
        public int Part2 { get; set; }
    }

    public class KaprekarNumber {

        public static IEnumerable<int> Enumerate() {
            for (int n = 1; n <= int.MaxValue; n++) {
                var kv = Analyze(n);
                if (kv != null)
                    yield return n;
            }
        }

        public static KaprekarValue Analyze(int x) {
            long x2 = (long)x * x;
            var xDigits = (int)Math.Log10(x) + 1;
            var x2Digits = (int)Math.Log10(x2) + 1;
            for (int n = x2Digits - xDigits; n <= x2Digits; n++) {
                var dn = (long)Math.Pow(10, n);
                var a = x2 / dn;
                var b = x2 % dn;
                if ((0 < b && b < dn) && (a + b == x)) {
                    return new KaprekarValue {
                        Number = x,
                        Part1 = (int)a,
                        Part2 = (int)b
                    };
                }
            }
            return null;
        }
    }
}
