using System;
using System.Collections.Generic;
using System.Linq;

namespace SubsetSumProblemApp {
    public class SubsetSumProblem {
        private int[] _nums;
        // numsの要素は、正整数とする
        public SubsetSumProblem(int[] nums) {
            this._nums = nums.ToArray();
        }

        private int[] _work;
        public int[] Solve(int target) {
            // 0. 配列pを用意する。サイズは、部分和(target)+1 とする。
            _work = new int[target + 1];
            // 1. 配列_workを初期化する _work[0] = 0, それ以外は -1 をセット。
            _work[0] = 0;
            for (int i = 1; i <= target; i++)
                _work[i] = -1;
            // 2. 集合からひとつ要素を取り出し、m とする。
            foreach (var m in _nums) {
                for (int i = target; i >= 0; i--) {
                    // 3. 配列pを最後から見ていき、-1 以外の時に、4の処理を行う
                    if (_work[i] == -1)
                        continue;
                    // 4. i + m <= target で、_work[i+m] == -1 ならば、_work[i+m] に m を代入する。
                    if (i + m <= target && _work[i + m] == -1)
                        _work[i + m] = m;
                }
                // 5. _work[target] != -1 ならば、解が見つかったので、処理を終了する。
                //    _work[target] == -1 ならば 1.に戻って処理を繰り返す。
                if (_work[target] != -1)
                    break;
            }
            return ToResult(_work, target);
        }

        // 作業用の配列から、部分集合を求める
        private int[] ToResult(int[] work, int target) {
            var result = new List<int>();
            if (work[target] != -1) {
                while (target > 0) {
                    result.Add(work[target]);
                    target = target - work[target];
                }
            }
            return (result as IEnumerable<int>).Reverse().ToArray();
        }
    }
}
