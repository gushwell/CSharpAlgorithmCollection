using System;
using System.Numerics;
using System.Text;

namespace PICalculatorByMachinsFormula {
    // 円周率の計算
    static class PICalculator {

        // 小数部figure桁までの円周率を求める
        public static string Calculate(int figure) {
            // マチンの公式により、円周率を求める
            BigInteger a = ArcCot(5, figure) * 4;
            BigInteger b = ArcCot(239, figure);
            BigInteger pi = (a - b) * 4;
            return pi.ToString().Substring(0, figure + 1);   // +1 は、整数部 表示用
        }

        // Calculateで求めた文字列を整形する。
        public static string Format(string s) {
            var sb = new StringBuilder();
            sb.Append(s.Substring(0, 1));
            sb.AppendLine(".");

            int j = 0;
            for (int i = 1; i < s.Length; i += 10) {
                sb.Append(s.Substring(i, Math.Min(10, s.Length - i)));
                sb.Append(" ");
                if (++j % 10 == 0)
                    sb.AppendLine();
            }
            return sb.ToString();
        }

        public static BigInteger ArcCot(int m, int figure) {
            var one = BigInteger.Pow(10, figure + 9);
            var mm = m * m;
            int sign = -1;
            BigInteger item = one / m;   // (1/m)
            BigInteger at = item;

            for (int step = 3; ; step += 2) {
                item = item / mm;
                var a = item / step;
                if (a == 0)
                    break;
                if (sign == 1)
                    at = at + a;
                else
                    at = at - a;
                sign = sign * -1;  // signをトグルさせる
            }
            return at;
        }
    }
}
