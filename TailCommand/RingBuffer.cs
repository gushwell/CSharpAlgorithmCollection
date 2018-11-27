using System;
using System.Collections;
using System.Collections.Generic;

namespace TailCommand {
    public class RingBuffer<T> : IEnumerable<T> {
        private int _size;
        private T[] _buffer;
        private int _writeIndex = -1;    // 書き終わった位置
        private bool _isFull = false;

        public RingBuffer(int size) {
            _size = size;
            _buffer = new T[size];
            _writeIndex = -1;
        }

        private int NextIndex(int ix) {
            return ++ix % _size;
        }

        private int GetStartIndex() {
            return _isFull ? NextIndex(_writeIndex) : 0;
        }


        public void Add(T value) {
            _writeIndex = NextIndex(_writeIndex);
            if (_writeIndex == _size - 1)
                _isFull = true;
            _buffer[_writeIndex] = value;
        }

        public bool Exists {
            get { return Count > 0; }
        }

        public int Count {
            get { return _isFull ? _size : _writeIndex + 1; }
        }

        public void Clear() {
            _writeIndex = -1;
            _isFull = false;
        }

        public IEnumerator<T> GetEnumerator() {
            var index = GetStartIndex();
            for (int i = 0; i < Count; i++) {
                yield return _buffer[index];
                index = NextIndex(index);
            }
        }
        IEnumerator IEnumerable.GetEnumerator() {
            return this.GetEnumerator();
        }
    }
}
