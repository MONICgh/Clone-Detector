using Cache;

void TestClearBeforeAdd()
{
    var maxSize = 3;
    var lifePeriod = new TimeSpan(0, 0, 0, 1);

    var cache = new Cache<List<int>.Enumerator>(maxSize, lifePeriod);

    var list = new List<int> { 1, 2, 3, 4 };
    cache.Add(list.GetEnumerator());
    cache.Add(list.GetEnumerator());
    cache.Add(list.GetEnumerator());
    Console.WriteLine($"Current items count: {cache.ItemsCount} (should be 3)");

    Thread.Sleep(2 * lifePeriod);

    cache.Add(list.GetEnumerator());
    Console.WriteLine($"Current items count: {cache.ItemsCount} (should be 1)");

    cache.Stop();
}

void TestClearBeforeGcCollect()
{
    var maxSize = 1_000;
    var lifePeriod = new TimeSpan(0, 0, 0, 1);

    var cache = new Cache<List<byte[]>.Enumerator>(maxSize, lifePeriod);
    var trashList = new List<byte[]>();
    cache.Add(trashList.GetEnumerator());
    Thread.Sleep(2_000);
    var lastCollCount = 0;

    while (true)
    {
        if (cache.ItemsCount != 1)
        {
            Console.WriteLine("No one element in cache! It is GC collection!");
            break;
        }

        trashList.Add(new byte[1_000]);
        
        var newCollCount = GC.CollectionCount(2);
        if (newCollCount != lastCollCount)
        {
            Console.WriteLine("Gen 2 collection count: {0}", newCollCount.ToString());
            lastCollCount = newCollCount;
        }
    }

    Console.WriteLine($"Current items count: {cache.ItemsCount} (should be 0)");
    cache.Add(trashList.GetEnumerator());
    Console.WriteLine($"Current items count: {cache.ItemsCount} (should be 1)");

    cache.Stop();
}

void Main()
{
    TestClearBeforeAdd();
    TestClearBeforeGcCollect();
}

Main();