namespace Cache;

public class CacheItem<T> where T : IDisposable
{
    private DateTime liftTime;
    private T item;
    
    public CacheItem(T item)
    {
        liftTime = DateTime.Now;
        this.item = item;
    }

    public override string ToString()
    {
        return $"CacheItem: {item}";
    }

    public T Get()
    {
        liftTime = DateTime.Now;
        return item;
    }

    public bool IsOld()
    {
        return liftTime < DateTime.Now;
    }

    public void Remove()
    {
        item.Dispose();
    }
}

public class Cache<T> where T : IDisposable
{
    private int maxSize;
    private TimeSpan? maxLifePeriod;
    private bool _is_finished;
    private Thread _thWaitForFullGc;

    private Dictionary<int, CacheItem<T>> storage;

    public int ItemsCount => storage.Count;

    public Cache(int maxSize, TimeSpan? lifePeriod)
    {
        _is_finished = false;
        
        GC.RegisterForFullGCNotification(10, 10);
        Console.WriteLine("Registered for GC notification.");
        
        this.maxSize = maxSize;
        maxLifePeriod = lifePeriod;
        storage = new Dictionary<int, CacheItem<T>>(maxSize);
        
        _thWaitForFullGc = new Thread(GCHandler);
        _thWaitForFullGc.Start();
        Console.WriteLine("Start GC handler.");
    }

    ~Cache()
    {
        Clear();
    }

    /// <summary>
    /// Interrupt GC handler thread
    /// </summary>
    public void Stop()
    {
        _is_finished = true;
        Console.WriteLine("Stopping...");
        _thWaitForFullGc.Interrupt();
        Console.WriteLine("Stop");
    }

    /// <summary>
    /// Call method Dispose from all old elements and remove it.
    /// </summary>
    /// <returns>true if one or more items were deleted and false else</returns>
    public bool Clear()
    {
        var freeIds = storage
            .Where((item) => item.Value.IsOld())
            .Select(item => item.Key);
        
        var deleted = false;
        foreach (var freeId in freeIds)
        {
            storage[freeId].Remove();
            storage.Remove(freeId);
            deleted = true;
        }

        return deleted;
    }

    /// <summary>
    /// Add new element to cache and return this object's ID.
    /// </summary>
    /// <param name="item">object to cache</param>
    /// <returns>object's ID</returns>
    public int Add(T item)
    {
        if (ItemsCount >= maxSize)
        {
            var hasFreeSpace = Clear();
            if (!hasFreeSpace)
            {
                throw new Exception("Cache is full and there are any unused object!");
            }
        }

        var newId = Utils.getNextIndex();
        storage[newId] = new CacheItem<T>(item);
        return newId;
    }

    /// <summary>
    /// Get item by ID.
    /// </summary>
    /// <param name="id">ID of item</param>
    /// <returns>item if this ID exists or null</returns>
    public T? Get(int id)
    {
        return storage.ContainsKey(id) ? storage[id].Get() : default;
    }

    private void GCHandler()
    {
        while (!_is_finished)
        {
            GCNotificationStatus s = GC.WaitForFullGCApproach();
            if (s == GCNotificationStatus.Succeeded)
            {
                Console.WriteLine("Start to clear cache");
                Clear();
                Console.WriteLine("Start GC.Collect");
                GC.Collect();
                Console.WriteLine("Finish GC.Collect");
            }
            Thread.Sleep(500);
        }   
    }
}