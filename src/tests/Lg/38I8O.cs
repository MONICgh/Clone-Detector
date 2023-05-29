namespace MultithreadArray;

public class MultiArray
{
    private readonly ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();
    private readonly List<int> _items;
    private readonly Random _random = new Random();

    public MultiArray(List<int> items)
    {
        _items = items;
    }
    
    public void Avg()
    {
        _lock.EnterReadLock();
        Thread.Sleep(_random.Next(1, 10) * 100);
        var avg = _items.Average();
        Console.WriteLine($"Current AVG = {avg}");
        _lock.ExitReadLock();
    }
    
    public void Min()
    {
        _lock.EnterReadLock();
        Thread.Sleep(_random.Next(1, 10) * 100);
        var min = _items.Min();
        Console.WriteLine($"Current MIN = {min}");
        _lock.ExitReadLock();
    }

    public void Swap()
    {
        _lock.EnterWriteLock();
        Thread.Sleep(_random.Next(1, 10) * 100);
        var i = _random.Next(0, _items.Count);
        var j = _random.Next(0, _items.Count);
        (_items[i], _items[j]) = (_items[j], _items[i]);
        Console.WriteLine($"Swap {i}th and {j}th");
        _lock.ExitWriteLock();
    }

    public void Sort()
    {
        _lock.EnterWriteLock();
        Thread.Sleep(_random.Next(1, 10) * 100);
        _items.Sort();
        Console.WriteLine("Sort items");
        _lock.ExitWriteLock();
    }
}