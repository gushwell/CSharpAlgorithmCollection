using System;
using System.Collections.Generic;

namespace PollardsRhoPrimeFactor {
    public class PrimeFactor {

        public IEnumerable<long> Enumerate(long n) {
            while (n > 1) {
                long factor = GetFactor(n);
                yield return factor;
                n = n / factor;
            }
        }

        private long GetFactor(long n, int seed = 1) {
            if (n % 2 == 0)
                return 2;
            if (IsPrime(n))
                return n;
            long x = 2;
            long y = 2;
            long d = 1;
            long count = 0;
            while (d == 1) {
                count++;
                x = f(x, n, seed);
                y = f(f(y, n, seed), n, seed);
                d = Gcd(Math.Abs(x - y), n);
            }
            if (d == n)
                // 見つからなかった、乱数発生のシードを変えて再挑戦。
                return GetFactor(n, seed + 1);
            // 素数でない可能性もあるので、再度呼び出す
            return GetFactor(d);
        }

        private int[] seeds = new int[] { 3, 5, 7, 11, 13, 17 };
        private long f(long x, long n, int seed) {
            return (seeds[seed % 6] * x + seed) % n;
        }

        private static long Gcd(long a, long b) {
            if (a < b)
                return Gcd(b, a);  // 引数を入替えて自分を呼び出す
            if (b == 0)
                return a;
            long d = 0;
            do {
                d = a % b;
                a = b;
                b = d;
            } while (d != 0);
            return a;
        }

        // 効率は良くないが、これでも十分な速度がでたので、良しとする。
        private static bool IsPrime(long number) {
            long boundary = (long)Math.Floor(Math.Sqrt(number));

            if (number == 1)
                return false;
            if (number == 2)
                return true;

            for (long i = 2; i <= boundary; ++i) {
                if (number % i == 0)
                    return false;
            }

            return true;
        }
    }
}
