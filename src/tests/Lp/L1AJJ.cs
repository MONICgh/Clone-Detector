namespace Cache;

public class Cache<T> where T : IDisposable
{
    private readonly Dictionary<int, T> storage;
    private readonly Dictionary<int, DateTime> timestamps;
    private readonly int maxSize;
    private readonly TimeSpan maxTime;
    private int index;
    private bool haveToClear;
    public int Count => storage.Count;

    public Cache(int maxSize, TimeSpan maxTime)
    {
        GC.RegisterForFullGCNotification(10, 10);
        new Thread(GCStatus).Start();
        this.maxSize = maxSize;
        this.maxTime = maxTime;
        storage = new Dictionary<int, T>();
        timestamps = new Dictionary<int, DateTime>();
        index = 0;
        haveToClear = false;
    }

    private void GCStatus()
    {
        while (GC.WaitForFullGCApproach() != GCNotificationStatus.Succeeded)
        {
        }

        haveToClear = true;
    }

    ~Cache()
    {
        Clear();
    }

    public int Add(T item)
    {
        if (Count + 1 > maxSize || haveToClear)
        {
            Clear();
        }

        if (Count + 1 > maxSize)
        {
            throw new Exception("Cannot clear the cache!");
        }

        storage[index] = item;
        timestamps[index] = DateTime.Now;
        return index++;
    }

    private void Clear()
    {
        var toRemove = (from kv in timestamps where kv.Value + maxTime < DateTime.Now select kv.Key).ToList();

        foreach (var id in toRemove)
        {
            storage[id].Dispose();
            storage.Remove(id);
            timestamps.Remove(id);
        }

        if (!haveToClear) return;
        new Thread(GCStatus).Start();
        haveToClear = false;
        Console.WriteLine("Cleared");
    }
}