using HomogeneousCache;

// Clear cache after adding an element
var timeout1 = new TimeSpan(TimeSpan.TicksPerSecond * 2);
var cache1 = new Cache<DisposableItem>(5, timeout1);
for (var i = 0; i < 5; i++)
{
    cache1.Add(new DisposableItem($"Item {i}"));
    Thread.Sleep(1000);
}
Thread.Sleep(timeout1);
cache1.Add(new DisposableItem("External item"));

Console.WriteLine("===============================================");

// Clear cache when full GC approaches
var timeout2 = new TimeSpan(TimeSpan.TicksPerSecond);
var cache2 = new Cache<DisposableItem>(1000, timeout2);
var garbageData = new List<byte[]>();
var prevCount = cache2.Count;
for (var i = 0; i < 1000; i++)
{
    cache2.Add(new DisposableItem($"Item {i}"));
    if (cache2.Count < prevCount)
    {
        break;
    }
    prevCount = cache2.Count;
    Thread.Sleep(1000);
    for (var j = 0; j < 1000; j++)
    {
        garbageData.Add(new byte[5000]);
    }
}