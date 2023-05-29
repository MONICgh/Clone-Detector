namespace ConcurrentArray;

public class ConcurrentArray
{
    private readonly List<int> _array;
    private readonly ReaderWriterLockSlim _locker;
    
    public ConcurrentArray(List<int> array)
    {
        _array = array;
        _locker = new ReaderWriterLockSlim();
    }
    
    public void Avg()
    {
        RunReadAction(() =>
        {
            var result = _array.Average();
            
            Console.WriteLine("Average: " + result);
        });
    }
    
    public void Min()
    {
        RunReadAction(() =>
        {
            var result = _array.Min();
            
            Console.WriteLine("Min: " + result);
        });
    }
    
    public void Swap()
    {
        RunWriteAction(() =>
        {
            var i = Random.Shared.Next(_array.Count);
            var j = Random.Shared.Next(_array.Count);
            (_array[i], _array[j]) = (_array[j], _array[i]);
            
            Console.WriteLine("Swap: array[" + i + "] = " + _array[i] + " <=> array[" + j + "] = " + _array[j]);
        });
    }
    
    public void Sort()
    {
        RunWriteAction(() =>
        {
            _array.Sort();
            
            Console.WriteLine("Sort: array = [" + string.Join(", ", _array) + "]");
        });
    }

    private void RunReadAction(Action action)
    {
        _locker.EnterReadLock();
        action();
        _locker.ExitReadLock();
    }
    
    private void RunWriteAction(Action action)
    {
        _locker.EnterWriteLock();
        action();
        _locker.ExitWriteLock();
    }
}