using System.Collections;
using System.Collections.Generic;

namespace FrogAndLake
{
    class Lake : IEnumerable<int>
    {
        private readonly List<int> _stones;

        public Lake(List<int> stones)
        {
            _stones = new List<int>(stones);
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (var i = 0; i < _stones.Count; i++)
            {
                if (i % 2 == 0)
                    yield return _stones[i];
            }

            for (var i = _stones.Count - 1; i >= 0; i--)
            {
                if (i % 2 != 0)
                    yield return _stones[i];
            }
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}