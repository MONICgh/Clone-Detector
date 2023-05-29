using System.Collections;

namespace SparseMatrix;

public class SparseMatrix<T> : IEnumerable<SparseItem<T>>
{
    private readonly Dictionary<Tuple<int, int, int>, T> _data = new ();

    public T? this[int x, int y, int z]
    {
        get
        {
            var key = new Tuple<int, int, int>(x, y, z);
            return _data.ContainsKey(key) ? _data[key] : default;
        }
        set
        {
            var key = new Tuple<int, int, int>(x, y, z);
            if (value == null || EqualityComparer<T>.Default.Equals(value, default))
            {
                _data.Remove(key);
            }
            else
            {
                _data[key] = value;
            }
        }
    }
    
    public IEnumerator<SparseItem<T>> GetEnumerator()
    {
        var itemsList = _data.Select(pair =>
            new SparseItem<T>(pair.Key.Item1, pair.Key.Item2, pair.Key.Item3, pair.Value)
        ).ToList();
        
        itemsList.Sort(new SparseItemComparator<T>());
        return itemsList.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}