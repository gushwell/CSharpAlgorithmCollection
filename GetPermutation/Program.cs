using System;

namespace GetPermutation {
    class Program {
        static void Main(string[] args) {
            // 確認用コード
            var perm = new Permutation();
            foreach (var n in perm.Enumerate(new[] { 1, 2, 3, 4 })) {
                foreach (var x in n)
                    Console.Write("{0} ", x);
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
