using System;
namespace ArrayRotationSample {
    static class ArrayRotation {
        // これが基準
        public static int[,] TurnLeft90(this int[,] array) {
            return array.RightDownDiagRotate().HorRotate();
        }
        public static int[,] TurnLeft180(this int[,] array) {
            return array.TurnLeft90().TurnLeft90();
        }
        public static int[,] TurnLeft270(this int[,] array) {
            return array.TurnLeft180().TurnLeft90();
        }
        public static int[,] TurnLeft360(this int[,] array) {
            return array.Clone() as int[,];
        }

        public static int[,] TurnRight90(this int[,] array) {
            return array.TurnLeft270();
        }
        public static int[,] TurnRight180(this int[,] array) {
            return array.TurnLeft180();
        }
        public static int[,] TurnRight270(this int[,] array) {
            return array.TurnLeft90();
        }
        public static int[,] TurnRight360(this int[,] array) {
            return array.Clone() as int[,];
        }
        public static int[,] VertRotate(this int[,] array) {
            return array.RightDownDiagRotate().TurnRight90();
        }

        // 中央横軸を中心に回転する
        public static int[,] HorRotate(this int[,] array) {
            var work = array.Clone() as int[,];
            int xLeng = work.GetLength(0);
            for (int x = 0; x < xLeng / 2; x++) {
                for (int y = 0; y < work.GetLength(1); y++) {
                    int temp = work[x, y];
                    work[x, y] = work[xLeng - x - 1, y];
                    work[xLeng - x - 1, y] = temp;
                }
            }
            return work;
        }

        public static int[,] RightUpDiagRotate(this int[,] array) {
            return array.TurnLeft180().RightDownDiagRotate();
        }
        // 左上から右下への斜め軸を中心に回転する
        public static int[,] RightDownDiagRotate(this int[,] array) {
            var work = array.Clone() as int[,];
            for (int y = 1; y < work.GetLength(1); y++) {
                for (int x = 0; x < y; x++) {
                    int temp = work[x, y];
                    work[x, y] = work[y, x];
                    work[y, x] = temp;
                }
            }
            return work;
        }
    }
}
