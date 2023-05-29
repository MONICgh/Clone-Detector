using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SparseMatrix
{
    public class SparseMatrix : IEnumerable<int>
    {
        private readonly Dictionary<Tuple<int, int, int>, int> _dict;

        public SparseMatrix()
        {
            _dict = new Dictionary<Tuple<int, int, int>, int>();
        }

        public int this[int i, int j, int k]
        {
            get => GetValue(i, j, k);
            set => SetValue(i, j, k, value);
        }

        private int GetValue(int i, int j, int k)
        {
            var key = new Tuple<int, int, int>(i, j, k);
            return _dict.ContainsKey(key) ? _dict[key] : 0;
        }

        private void SetValue(int i, int j, int k, int value)
        {
            var key = new Tuple<int, int, int>(i, j, k);
            _dict[key] = value;
            if (value == 0)
            {
                _dict.Remove(key);
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            return _dict.Select(item => item.Value).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}