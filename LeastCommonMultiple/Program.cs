using System;

namespace LeastCommonMultiple {
    class Program {
        static void Main(string[] args) {
            var lcm = Lcm(28, 34);
            Console.WriteLine(lcm);
        }

        // 最小公倍数
        public static int Lcm(int a, int b) {
            return a * b / Gcd(a, b);
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
    }
}
