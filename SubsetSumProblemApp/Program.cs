using System;
using System.Linq;

namespace SubsetSumProblemApp {
    class Program {
        static void Main(string[] args) {
            // 問題の集合と部分和を入力する（手抜き）
            Console.Write("集合=> ");
            var strs = Console.ReadLine().Split(',');
            int[] nums = strs.Select(s => int.Parse(s.Trim())).ToArray();

            while (true) {
                Console.Write("ターゲット=> ");
                var line = Console.ReadLine();
                if (line == "")
                    break;
                int target = int.Parse(line);

                // 問題を解く
                var ssp = new SubsetSumProblem(nums);
                var ans = ssp.Solve(target);

                if (ans.Length > 0) {
                    // 解が見つかったので、解を表示する。
                    var ansStrings = ans.Select(n => n.ToString()).ToArray();
                    var text = string.Join(" + ", ansStrings) + " = " + target;
                    Console.WriteLine(text);
                } else {
                    Console.WriteLine("解は存在しません");
                }
            }
            Console.ReadLine();
        }
    }
}
