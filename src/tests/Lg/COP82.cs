namespace MultithreadArray;

public class MTArray
{
    private int[] array;
    private int n;
    private ReaderWriterLockSlim rwLock = new ReaderWriterLockSlim();
    private Random rng = new Random();

    public MTArray(int[] a)
    {
        array = a;
        n = array.Length;
    }

    public void TAvg()
    {
        rwLock.EnterReadLock();
        Console.WriteLine($"Average: {1.0 * array.Sum() / n}; Array: {string.Join(' ', array)}");
        rwLock.ExitReadLock();
        Thread.Sleep(rng.Next(500, 2000));
    }
    
    public void TMin()
    {
        rwLock.EnterReadLock();
        Console.WriteLine($"Min: {array.Min()}; Array: {string.Join(' ', array)}");
        rwLock.ExitReadLock();
        Thread.Sleep(rng.Next(500, 2000));
    }
    
    public void TSort()
    {
        rwLock.EnterWriteLock();
        Array.Sort(array);
        Console.WriteLine($"Sort; Array: {string.Join(' ', array)}");
        rwLock.ExitWriteLock();
        Thread.Sleep(rng.Next(500, 2000));
    }

    public void TSwap()
    {
        rwLock.EnterWriteLock();
        var i = rng.Next() % n;
        var j = rng.Next() % n;
        (array[i], array[j]) = (array[j], array[i]);
        Console.WriteLine($"Swap: {i + 1} and {j + 1}; Array: {string.Join(' ', array)}");
        rwLock.ExitWriteLock();
        Thread.Sleep(rng.Next(500, 2000));
    }
}