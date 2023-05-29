using System.Collections;

namespace Task5;

public class BigRangeArray<T> : IEnumerable<T>
{
    private readonly Dictionary<Tuple<int, int, int>, T> _data = new Dictionary<Tuple<int, int, int>, T>();

    public T this[int i, int j, int k]
    {
        get => _data[new Tuple<int, int, int>(i, j, k)];
        set => _data[new Tuple<int, int, int>(i, j, k)] = value;
    }
    
    public T this[int i, int j]
    {
        get => _data[new Tuple<int, int, int>(i, j, -1)];
        set => _data[new Tuple<int, int, int>(i, j, -1)] = value;
    }
    
    public IEnumerator<T> GetEnumerator()
    {
        return _data.Values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}