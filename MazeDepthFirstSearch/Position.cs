using System;
namespace MazeDepthFirstSearch {
    // 位置情報構造体
    public struct Position {
        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString() {
            return $"({X},{Y})";
        }
    }
    // Position
    public enum Direction {
        None,
        East,
        West,
        South,
        North
    }

    public enum Place {
        Wall,
        Path,
        Goal,
        Start
    }

}
