namespace HW_11.Cache;

public class Cache<T> : IDisposable where T : IDisposable
{
    public long MaxTimeSeconds { get; set; } = long.MaxValue;
    public long MaxCacheSize { get; set; } = long.MaxValue;

    private Dictionary<int, long> _elementTimes = new();
    private Dictionary<int, T> _elements = new();
    public event EventHandler GCApproaches;
    private Thread watcherThread;
    public void Watch()
    {
        GC.RegisterForFullGCNotification(50, 50);
        watcherThread = new Thread(() =>
        {
            while (true)
            {
                GCApproaches?.Invoke(this, EventArgs.Empty);
                if (GCApproaches == null)
                    continue;
                GCApproaches += (_, _) =>
                {
                    ProperKeyRemoval(_elements.Keys.ToList());
                };
                break;
            }
        })
        {
            IsBackground = true
        };

        watcherThread.Start();
    }

    public void Add(int key, T elem)
    {
        if (_elements.Count == MaxCacheSize)
        {
            RemoveOld();
        }
        if (_elements.Count == MaxCacheSize)
        {
            RemoveOne();
        }
        _elementTimes.Add(key, DateTimeOffset.Now.ToUnixTimeSeconds());
        _elements.Add(key, elem);
    }

    public T? Get(int key)
    {
        if (!_elements.ContainsKey(key))
            return default(T);
        _elementTimes[key] = DateTimeOffset.Now.ToUnixTimeSeconds();
        return _elements[key];
    }

    private void ProperKeyRemoval(List<int> keys)
    {
        foreach (var keyValuePair in _elements.Where(pair => !keys.Contains(pair.Key)))
        {
            keyValuePair.Value.Dispose();
        }

        _elements = WithRemovedKeys(_elements, keys);
        _elementTimes = WithRemovedKeys(_elementTimes, keys);
    }
    private void RemoveOld()
    {
        var time = DateTimeOffset.Now.ToUnixTimeSeconds();
        var keys = _elements.Keys.Where(it => time - _elementTimes[it] > MaxTimeSeconds).ToList();
        ProperKeyRemoval(keys);
    }

    private void RemoveOne()
    {
        var key = _elements.Keys.Take(1).ToList();
        ProperKeyRemoval(key);
    }

    private static Dictionary<int, TB> WithRemovedKeys<TB>(Dictionary<int, TB> dict, ICollection<int> keys)
    {
        return dict.Where(pair => keys.Contains(pair.Key)).ToDictionary(i => i.Key, i => i.Value);
    }


    public void Dispose()
    {
        watcherThread.Join();
    }
}
