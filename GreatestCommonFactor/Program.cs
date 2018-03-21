using System;

namespace GreatestCommonFactor {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(Gcd(0, 8));
            Console.WriteLine(Gcd(12, 8));
            Console.WriteLine(Gcd(3400, 6596));
            Console.WriteLine(Gcd(12707, 12319));

            Console.WriteLine(GcdRecursion(0, 8));
            Console.WriteLine(GcdRecursion(12, 8));
            Console.WriteLine(GcdRecursion(3400, 6596));
            Console.WriteLine(GcdRecursion(12707, 12319));
        }

        // ユークリッドの互除法 
        public static int Gcd(int a, int b) {
            if (a < b)
                // 引数を入替えて自分を呼び出す
                return Gcd(b, a);
            while (b != 0) {
                var remainder = a % b;
                a = b;
                b = remainder;
            }
            return a;
        }

        // ユークリッドの互除法  再帰バージョン
        public static int GcdRecursion(int a, int b) {
            Func<int, int, int> gcd = null;
            gcd = (x, y) => y == 0 ? x : gcd(y, x % y);
            return a > b ? gcd(a, b) : gcd(b, a);
        }
    }
}
