using System;
using System.Collections.Generic;
using System.Linq;

namespace BetrothedNumber {
    class Program {
        static void Main(string[] args) {
            var numbers = BetrothedNumbers.GetNumbers().Take(20);
            foreach (var p in numbers)
                Console.WriteLine(p);
        }
    }

    public class Pair {
        public long Value1 { get; set; }
        public long Value2 { get; set; }
        public override string ToString() {
            return string.Format("({0}, {1})", Value1, Value2);
        }
    }
    public class BetrothedNumbers {
        public static IEnumerable<Pair> GetNumbers() {
            for (long i = 1; i < long.MaxValue; i++) {
                long x = Divisors(i).Sum();
                if (i >= x)
                    continue;
                long y = Divisors(x).Sum();
                if (i == y)
                    yield return new Pair { Value1 = i, Value2 = x };
            }
        }

        public static IEnumerable<long> Divisors(long n) {
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