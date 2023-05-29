namespace HomogeneousCache;

public class Cache<T> where T : class, IDisposable
{
    private readonly int _capacity;
    private readonly TimeSpan _timeInterval;

    private int _currentIndex;
    private bool _clearGC;
    
    private readonly Dictionary<int, T> _data;
    private readonly Dictionary<int, DateTime> _timestamp;

    public Cache(int capacity, TimeSpan timeInterval)
    {
        _capacity = capacity;
        _timeInterval = timeInterval;
        _currentIndex = 0;
        _clearGC = false;
        _data = new Dictionary<int, T>();
        _timestamp = new Dictionary<int, DateTime>();
        GC.RegisterForFullGCNotification(10, 10);
        StartGCCheck();
    }

    ~Cache()
    {
        Clear();
    }

    public int Count => _data.Count;

    public int? Add(T element)
    {
        ClearIfNeeded();

        if (MaxCapacityExceeded())
        {
            return null;
        }

        _data[_currentIndex] = element;
        _timestamp[_currentIndex] = DateTime.Now;
        _currentIndex += 1;
        
        Console.WriteLine($"New element {element} added at index {_currentIndex - 1} at {DateTime.Now}.");

        return _currentIndex - 1;
    }
    
    public T? Get(int index)
    {
        ClearIfNeeded();
        
        if (!_data.ContainsKey(index))
        {
            return null;
        }
        
        _timestamp[index] = DateTime.Now;
        
        return _data[index];
    }

    private bool MaxCapacityExceeded()
    {
        return Count >= _capacity;
    }

    private void ClearIfNeeded()
    {
        if (_clearGC || MaxCapacityExceeded())
        {
            Clear();
        }
    }

    private void Clear()
    {
        var indicesToRemove = new List<int>();
        foreach (var (index, timestamp) in _timestamp)
        {
            if (DateTime.Now - timestamp > _timeInterval)
            {
                indicesToRemove.Add(index);
            }
        }

        foreach (var index in indicesToRemove)
        {
            Console.WriteLine($"Element {_data[index]} at index {index} removed and disposed at {DateTime.Now}.");
            _data[index].Dispose();
            _data.Remove(index);
            _timestamp.Remove(index);
        }

        if (_clearGC)
        {
            StartGCCheck();
            _clearGC = false;
        }
    }
    
    private void CheckGC()
    {
        while (true)
        {
            if (GC.WaitForFullGCApproach() == GCNotificationStatus.Succeeded)
            {
                _clearGC = true;
                break;
            }
        }
    }

    private void StartGCCheck()
    {
        new Thread(CheckGC).Start();
    }
}