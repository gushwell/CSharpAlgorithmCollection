using System;
using System.Collections.Generic;
using System.Linq;

namespace MazeBreadthFirstSearch {
    // 経路を表すクラス 位置と進行方向からなる
    public class Tracks {
        private List<Direction> _directionPath = new List<Direction>();
        private List<Position> _positionPath = new List<Position>();

        // コンストラクタ
        public Tracks() {
            _directionPath.Add(Direction.None);
            _positionPath.Add(new Position { X = 0, Y = 0 });
        }

        // 進行方向の履歴
        public IEnumerable<Direction> GetDirectionPath() {
            return _directionPath;
        }

        // 位置の履歴
        public IEnumerable<Position> GetPositionPathh() {
            return _positionPath;
        }

        // 経路を追加
        public void Add(Position pos, Direction dir) {
            _positionPath.Add(pos);
            _directionPath.Add(dir);
        }

        // 最後の位置と方向を取得
        public (Position, Direction) Last() {
            return (_positionPath.Last(), _directionPath.Last());
        }

        // 現在の位置と方向を取得
        public (Position, Direction) Current {
            get {
                return (_positionPath.Last(), _directionPath.Last());
            }
        }

        public Tracks Clone() {
            var obj = new Tracks() {
                _directionPath = this._directionPath.ToList(),
                _positionPath = this._positionPath.ToList()
            };
            return obj;
        }

    }
}
