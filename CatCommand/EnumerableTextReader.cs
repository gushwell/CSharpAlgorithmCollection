using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace CatCommand {
    public class EnumerableTextReader : IEnumerable<string> {
        private TextReader _sr;

        public EnumerableTextReader(TextReader tr) => _sr = tr;

        public EnumerableTextReader(Stream s) => _sr = new StreamReader(s);

        public IEnumerator<string> GetEnumerator() {
            string s;
            while ((s = _sr.ReadLine()) != null) {
                yield return s;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    }
}
