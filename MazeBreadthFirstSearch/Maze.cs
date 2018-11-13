using System;
using System.IO;

namespace MazeBreadthFirstSearch {
    // 迷路クラス
    public class Maze {
        private char[,] _map;
        public int XSize { get; private set; }
        public int YSize { get; private set; }

        private Position _start;

        // コンストラクタ
        public Maze(string mapfile) {
            ReadMap(mapfile);
            _start = FindPosition('S');
        }

        // Mapデータを読み込む
        public void ReadMap(string mapfile) {
            string[] map = File.ReadAllLines(mapfile);
            this._map = new char[map[0].Length, map.Length];
            for (int y = 0; y < map.Length; y++) {
                var line = map[y];
                for (int x = 0; x < line.Length; x++) {
                    this._map[x, y] = line[x];
                }
            }
            XSize = map[0].Length;
            YSize = map.Length;
        }

        // インデクサ （これは、表示のみに利用する)
        public char this[int x, int y] {
            get { return _map[x, y]; }
        }

        // relativeの場所が何かを返す
        public Place Look(Position relative) {
            var pos = GetAbsolutePosition(relative);
            // pos = GetPosition(pos, direction);
            if (pos.X < 0 || pos.X >= this.XSize)
                return Place.Wall;
            if (pos.Y < 0 || pos.Y >= this.YSize)
                return Place.Wall;
            switch (_map[pos.X, pos.Y]) {
                case 'G':
                    return Place.Goal;
                case 'S':
                    return Place.Start;
                case ' ':
                    return Place.Path;
                default:
                    return Place.Wall;
            }
        }

        // 相対位置から絶対位置に変換 （相対位置は、startの位置を基準とする)
        public Position GetAbsolutePosition(Position relative) {
            return new Position {
                X = _start.X + relative.X,
                Y = _start.Y + relative.Y
            };
        }

        // target で指定した文字がある場所を求める。
        public Position FindPosition(char target) {
            for (int x = 0; x < XSize; x++) {
                for (int y = 0; y < YSize; y++) {
                    if (_map[x, y] == target)
                        return new Position { X = x, Y = y };
                }
            }
            throw new ApplicationException();
        }


        // Positionは値型なので、呼び出し元には影響を与えない
        public static Position GetPosition(Position current, Direction direction) {
            switch (direction) {
                case Direction.South:
                    current.Y++;
                    break;
                case Direction.East:
                    current.X++;
                    break;
                case Direction.North:
                    current.Y--;
                    break;
                case Direction.West:
                    current.X--;
                    break;
            }
            return current;
        }

        // 反対方向を求める
        public static Direction BackDirection(Direction direction) {
            switch (direction) {
                case Direction.South:
                    return Direction.North;
                case Direction.East:
                    return Direction.West;
                case Direction.North:
                    return Direction.South;
                case Direction.West:
                    return Direction.East;
            }
            return Direction.None;
        }

    }
}
