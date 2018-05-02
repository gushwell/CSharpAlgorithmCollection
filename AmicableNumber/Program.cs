using System;
using System.Collections.Generic;
using System.Linq;

namespace AmicableNumber {
    class Program {
        public static void Main(string[] args) {
            AmicableNumbers an = new AmicableNumbers();
            var numbers = an.GetNumbers()
                            .Take(20);
            foreach (var pair in numbers) {
                Console.WriteLine("({0} , {1})", pair.Value1, pair.Value2);
            }
        }
    }

    public class Pair {
        public long Value1 { get; set; }
        public long Value2 { get; set; }
    }

    public class AmicableNumbers {
        // long の範囲で、友愛数を列挙する
        public IEnumerable<Pair> GetNumbers() {
            for (long i = 2; i < long.MaxValue; i++) {
                long x = Divisors(i).Sum();
                if (i >= x)
                    continue;
                long y = Divisors(x).Sum();
                if (i == y)
                    yield return new Pair { Value1 = i, Value2 = x };
            }
        }

        // 真の約数を求める n は、2以上の整数
        private IEnumerable<long> Divisors(long n) {
            yield return 1;
            long m = (long)Math.Sqrt(n);
            if (m * m == n) {
                yield return m;
                m--;
            }
            for (long i = 2; i <= m; i++) {
                if (n % i == 0) {
                    yield return i;
                    yield return n / i;
                }
            }
        }
    }
}
