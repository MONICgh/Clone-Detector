namespace Task1;

public class MyCache<T> where T: class, IDisposable
{
    private readonly T?[] _data;
    private readonly DateTime[] _lastDateTime;
    private readonly TimeSpan _maxDelay;
    private readonly Queue<int> _frees;
    private readonly Thread _thread;
    private volatile bool _stopped;

    public MyCache(int maxSize, TimeSpan maxDelay)
    {
        _data = new T?[maxSize];
        _lastDateTime = new DateTime[maxSize];
        _maxDelay = maxDelay;
        _frees = new Queue<int>();
        for (int i = 0; i < maxSize; i++)
        {
            _frees.Enqueue(i);
        }
        _stopped = false;
        GC.RegisterForFullGCNotification(10, 10);
        _thread = new Thread(gcWaiter);
        _thread.Start();
    }

    public T? Get(int id)
    {
        if (id < 0 || id >= _data.Length)
        {
            return null;
        }

        _lastDateTime[id] = DateTime.Now; 
        return _data[id];
    }

    public int? Add(T el)
    {
        int t;
        if (!_frees.TryDequeue(out t))
        {
            Clear();
            if (!_frees.TryDequeue(out t))
            {
                return null;
            }            
        }

        _data[t] = el;
        _lastDateTime[t] = DateTime.Now;
        return t;
    }

    private void Clear()
    {
        for (int i = 0; i < _data.Length; i++)
        {
            if (_data[i] != null && DateTime.Now - _lastDateTime[i] > _maxDelay)
            {
                _data[i]?.Dispose();
                _data[i] = null;
                _frees.Enqueue(i);
            }
        }
    }

    private void gcWaiter()
    {
        while (true)
        {
            if (GC.WaitForFullGCApproach() == GCNotificationStatus.Succeeded)
            {
                Clear();
            }
            if (_stopped)
                break;
        }
    }

    ~MyCache()
    {
        _stopped = true;
        Clear();
    }
}