using System.Collections;

namespace FrogAndLake;

public class Lake : IEnumerable<int>
{
    private readonly List<int> _stones;

    public Lake(List<int> stones)
    {
        _stones = stones;
    }
    
    public IEnumerator<int> GetEnumerator()
    {
        var iter = 0;

        for (; iter < _stones.Count; iter += 2)
        {
            yield return _stones[iter];
        }

        iter -= 1;
        if (_stones.Count % 2 == 1)
        {
            iter -= 2;
        }

        for (; iter >= 0; iter -= 2)
        {
            yield return _stones[iter];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}