using System;

namespace ArrayRotationSample {
    class Program {
        static void Main(string[] args) {
            var array = new int[,] {
                // array[x,y]でアクセス。x軸が縦、y軸が横
                // array[0,2]->13  array[4,0]-> 51
                { 11, 12, 13, 14, 15, 16, 17, 18, 19 },
                { 21, 22, 23, 24, 25, 26, 27, 28, 29 },
                { 31, 32, 33, 34, 35, 36, 37, 38, 39 },
                { 41, 42, 43, 44, 45, 46, 47, 48, 49 },
                { 51, 52, 53, 54, 55, 56, 57, 58, 59 },
                { 61, 62, 63, 64, 65, 66, 67, 68, 69 },
                { 71, 72, 73, 74, 75, 76, 77, 78, 79 },
                { 81, 82, 83, 84, 85, 86, 87, 88, 89 },
                { 91, 92, 93, 94, 95, 96, 97, 98, 99 }
            };

            Console.WriteLine("オリジナル");
            Print(array);
            Console.WriteLine("左90度回転");
            Print(array.TurnLeft90());
            Console.WriteLine("左180度回転");
            Print(array.TurnLeft180());
            Console.WriteLine("左270回転");
            Print(array.TurnLeft270());
            Console.WriteLine("左360度回転");
            Print(array.TurnLeft360());
            Console.WriteLine("右90度回転");
            Print(array.TurnRight90());
            Console.WriteLine("右180度回転");
            Print(array.TurnRight180());
            Console.WriteLine("右270度回転");
            Print(array.TurnRight270());
            Console.WriteLine("右360度回転");
            Print(array.TurnRight360());
            Console.WriteLine("水平軸回転");
            Print(array.HorRotate());
            Console.WriteLine("垂直軸回転");
            Print(array.VertRotate());
            Console.WriteLine("右下がり斜線軸回転");
            Print(array.RightDownDiagRotate());
            Console.WriteLine("右上がり斜線軸回転");
            Print(array.RightUpDiagRotate());
        }

        static void Print(int[,] array) {
            for (int x = 0; x < array.GetLength(0); x++) {
                for (int y = 0; y < array.GetLength(1); y++)
                    Console.Write($"{array[x, y],3}");
                Console.WriteLine();
            }
            Console.WriteLine();

        }
    }

}
