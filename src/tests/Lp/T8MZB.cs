// See https://aka.ms/new-console-template for more information

using Cache;

void AfterAddTest()
{
    Console.WriteLine("AfterAddTest");
    var cache = new Cache<DisposableItem>(3, new TimeSpan(0, 0, 1));
    cache.Add(new DisposableItem("A"));
    cache.Add(new DisposableItem("B"));
    cache.Add(new DisposableItem("C"));
    Console.WriteLine($"Cache Count {cache.Count}");
    Console.WriteLine("Adding new item after sleep");
    Thread.Sleep(2000);
    cache.Add(new DisposableItem("D"));
    Console.WriteLine($"Cache Count {cache.Count}");
}

void AlmostFullTest()
{
    Console.WriteLine("AlmostFullTest");
    var cache = new Cache<DisposableItem>(1000000, new TimeSpan(0, 0, 1));
    for (var i = 1; i <= 10; ++i)
    {
        var s = i.ToString();
        for (var it = 0; it < 1000000; ++it)
        {
            var _ = new DisposableItem(s);
        }

        cache.Add(new DisposableItem(s));
        Thread.Sleep(2000);
        Console.WriteLine($"Cache Count {cache.Count}");
    }
}

AfterAddTest();
AlmostFullTest();

