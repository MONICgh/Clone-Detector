using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Lifetime;

namespace Lake
{
    public class Lake<T> : IEnumerable<T>
    {
        private readonly List<T> _list;
        private readonly int _n;

        public Lake(List<T> list)
        {
            _list = list;
            _n = list.Count;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = 0; i < _n; i += 2)
            {
                yield return _list[i];
            }

            for (var i = _n - 1 - _n % 2; i >= 0; i -= 2)
            {
                yield return _list[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}