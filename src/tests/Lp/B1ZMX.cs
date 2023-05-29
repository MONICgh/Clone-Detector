using System.Diagnostics;
using Task1;

void PrintMaybeNull<T>(T value) =>
    Console.WriteLine(value == null ? "null" : value);

void ClearAfterAddingTest()
{
    const int maxSize = 10;
    var maxDelay = new TimeSpan(0, 0, 1);
    var cache = new MyCache<CustomFileStream>(maxSize, maxDelay);
    
    for (var i = 0; i < maxSize; ++i)
    {
        Debug.Assert(cache.Add(new CustomFileStream(i + ".txt")) != null);
    }
    
    Debug.Assert(cache.Add(new CustomFileStream("a.txt")) == null);
    
    Thread.Sleep(maxDelay * 2);

    var onlyId = cache.Add(new CustomFileStream("b.txt"));
    Debug.Assert(onlyId != null);
    
    for (var id = 0; id < maxSize; id++) 
    {
        if (id == onlyId)
        {
            Debug.Assert(cache.Get(id) != null);
        }
        else
        {
            Debug.Assert(cache.Get(id) == null);
        }
    }
    //cache.Interrupt();
    Console.WriteLine("Test ClearAfterAddingTest is Okay!");
}

void ClearAfterGCTest()
{
    const int maxSize = 10;
    var maxDelay = new TimeSpan(0, 0, 0, 0, 250);
    var cache = new MyCache<CustomFileStream>(maxSize, maxDelay);

    var id = cache.Add(new CustomFileStream("c.txt"));
    Debug.Assert(id != null);

    List<int[]> trash = new List<int[]>();
    Debug.Assert(cache.Get(id.Value) != null);
    
    Thread.Sleep(maxDelay * 2);
    
    Debug.Assert(cache.Get(id.Value) != null);
    Thread.Sleep(maxDelay * 2);
    
    for (var i = 0; i < 100; i++)
    {
        trash.Add(new int[1000]);
    }

    Debug.Assert(cache.Get(id.Value) != null);
    
    Thread.Sleep(maxDelay * 2);
    for (var i = 0; i < 100000; i++)
    {
        
        trash.Add(new int[1000]);
    }

    Debug.Assert(cache.Get(id.Value) == null);
    Console.WriteLine("Test ClearAfterGCTest is Okay");
}

ClearAfterAddingTest();
ClearAfterGCTest();
Environment.Exit(0);
