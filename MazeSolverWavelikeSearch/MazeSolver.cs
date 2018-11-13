using System;
namespace MazeSolverWavelikeSearch {
    // 波状探索
    public class MazeSolver {
        public Maze Solve(Maze maze) {
            Maze workmaze = maze.Clone();
            int step = 0;    // step は、何歩目かを示す。今は 0 歩目
            while (!workmaze.IsFin()) {
                foreach (var pos in workmaze.SeachLocations(step)) {
                    foreach (var next in workmaze.NextPositions(pos)) {
                        workmaze.FootMark(next, step + 1);
                    }
                }
                step++;  // 歩数を一歩進める
                // 次の２行はデバッグ用
                //workmaze.DebugPrint();
                //Console.ReadLine();
            }
            return workmaze;
        }
    }
}
