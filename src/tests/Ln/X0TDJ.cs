namespace Task1;

public class OpenHashMap<T>
{
    private T? _defaultT = default(T); 
    private T?[] _array;
    private bool[] _used;
    private readonly uint _capacity;
    
    public OpenHashMap(uint capacity = 1000)
    {
        _capacity = capacity;
        _array = new T?[capacity];
        _used = new bool[capacity];
    }

    public void Add(T el)
    {
        var hash = (uint)el.GetHashCode() % _capacity;
        var t = hash;
        
        do
        {
            if (_used[t] == false)
            {
                _array[t] = el;
                _used[t] = true;
            }

            if (Equals(_array[t], el))
            {
                return;
            }
            
            t++;
            t %= _capacity;
        } while (t != hash);
    }

    public bool Contains(T el)
    {
        var hash = (uint)el.GetHashCode() % _capacity;
        var t = hash;
        do
        {
            if (_array[t] == null)
            {
                return false;
            }

            if (Equals(_array[t], el))
            {
                return true;
            }
            
            t++;
            t %= _capacity;
        } while (t != hash);

        return false;
    }

    // returns true, if element exists, otherwise - false
    public bool Delete(T el)
    {
        var hash = (uint)el.GetHashCode() % _capacity;
        var t = hash;
        do
        {
            if (_used[t] == false)
            {
                return false;
            }

            if (Equals(_array[t], el))
            {
                _array[t] = _defaultT;
                _used[t] = false;
                return true;
            }
            
            t++;
            t %= _capacity;
        } while (t != hash);

        return false;
    }
}