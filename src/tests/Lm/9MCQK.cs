using System.Collections;

namespace Task1;

public class Lake : IEnumerable<int>
{
    private readonly List<int> _numbers;

    public Lake(List<int> numbers)
    {
        _numbers = numbers;
    }
    
    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 0; i < _numbers.Count; i += 2)
        {
            yield return _numbers[i];
        }

        var last = _numbers.Count - 1;
        if (last % 2 != 1)
            last--;
        for (int i = last; i > 0; i -= 2)
        {
            yield return _numbers[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}