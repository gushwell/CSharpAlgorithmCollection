using System;
using System.Collections.Generic;
using System.Linq;

namespace TriangularNumberApp {

    public static class TriangularNumber {
        // 三角数を列挙する
        public static IEnumerable<int> Take(int n) {
            yield return 0;
            int ans = 0;
            for (int i = 1; i < n; i++) {
                ans += i;
                yield return ans;
            }
        }

        // 三角数かを調べる
        public static bool IsCorrect(long x) {
            long a = 8 * x + 1;
            long b = (long)(Math.Sqrt(a));
            if (b * b != a)
                return false;
            return (b - 1) % 2 == 0;
        }

        // ｎ番目の三角数を求める
        public static long GetAt(int nth) {
            return (long)nth * (nth + 1) / 2;
        }
    }
}
