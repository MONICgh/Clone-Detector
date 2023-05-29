using System.Collections;
using System.Collections.Generic;

namespace task1
{
    class Lake : IEnumerable<int>
    {
        private readonly List<int> _stones;

        public Lake(List<int> stones)
        {
            _stones = stones;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < _stones.Count; i+=2)
            {
                    yield return _stones[i];
                
            }

            if (_stones.Count %2  != 0)
            {
                for (int i = _stones.Count - 2; i >= 0; i-=2)
                {
                    yield return _stones[i];
                }
            }
            else
            {
                for (int i = _stones.Count - 1; i >= 0; i -= 2)
                {
                    yield return _stones[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
