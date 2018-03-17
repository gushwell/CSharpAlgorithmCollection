using System;

namespace FactorialSample {
    class Program {
        static void Main(string[] args) {
            for (var n = 0; n < 15; n++)
                Console.WriteLine(Factorial(n));
        }

        // 再帰処理で、nの階乗を計算する　　
        public static long Factorial(int n) {
            checked {
                if (n == 0)
                    return 1L;
                return n * Factorial(n - 1);
            }
        }
    }
}
