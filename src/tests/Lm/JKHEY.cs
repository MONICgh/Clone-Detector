using System.Collections;
using System.Collections.Generic;

namespace FrogAndLake;

public class Lake : IEnumerable<int>
{

    private List<int> stones;

    public Lake(List<int> stones)
    {
        this.stones = stones;
    }

    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 0; i < stones.Count; i += 2)
        {
            yield return stones[i];
        }

        int lastOddIndex = stones.Count / 2 * 2 - 1;

        for (int i = lastOddIndex; i > 0; i -= 2)
        {
            yield return stones[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}