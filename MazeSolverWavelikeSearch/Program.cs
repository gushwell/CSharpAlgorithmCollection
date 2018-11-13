using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.IO;

namespace MazeSolverWavelikeSearch {
    class Program {
        static void Main(string[] args) {
            var sw = Stopwatch.StartNew();
            var solver = new MazeSolver();
            Maze ans = solver.Solve(new Maze("maze.txt"));
            sw.Stop();
            Console.WriteLine("{0}ミリ秒", sw.ElapsedMilliseconds);
            ans.Print();
            Console.ReadLine();
        }
    }
}