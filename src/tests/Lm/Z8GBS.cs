using System.Collections;

namespace Frog
{
    public class Lake : IEnumerable<int>
    {
        private readonly List<int> stones;
        public Lake(List<int> _stones)
        {
            stones = _stones;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < stones.Count; i += 2)
            {
                yield return stones[i];
            }
            int revStart = stones.Count % 2 == 1 ? stones.Count - 2 : stones.Count - 1;
            for (int i = revStart; i > 0; i -= 2)
            {
                yield return stones[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}