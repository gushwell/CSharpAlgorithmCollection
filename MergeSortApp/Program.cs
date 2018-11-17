using System;
using System.Collections.Generic;
using System.Linq;

namespace MergeSortApp {
    // MergeSortの検証用コード
    class Program {
        static void Main(string[] args) {
            Random rnd = new Random();
            var nums = new int[10000];
            for (int count = 0; count < 10; count++) {
                for (int i = 0; i < nums.Length; i++) {
                    nums[i] = rnd.Next(1, 10000);
                }

                var result = MargeSort.Sort(nums, (a, b) => a - b);
                // LINQのOrderByメソッドの結果と比較することで、MergeSortが正しく整列されているかを確認している
                bool isEqual = Enumerable.SequenceEqual(result, nums.OrderBy(n => n));
                Console.WriteLine(isEqual);
            }
            Console.WriteLine("end");
        }
    }
}