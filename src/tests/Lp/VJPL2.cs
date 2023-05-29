using NUnit.Framework;

namespace HW_11.Cache;

internal class Local : IDisposable
{
    public int X { get; }
    public List<int> removed;
    public Local(int x, List<int> removed)
    {
        this.X = x;
        this.removed = removed;
    }
    public void Dispose()
    {
        removed.Add(X);
    }
}

[TestFixture]
public class Test
{
    [Test]
    public void Check()
    {
        var list = new List<int>();
        var cache = new Cache<Local>();
        cache.MaxCacheSize = 1;
        cache.MaxTimeSeconds = 0;

        cache.Add(1, new Local(3, list));
        cache.Add(2, new Local(2, list));
        Assert.AreEqual(list, new List<int> { 3 });
    }


    [Test]
    public void Check2()
    {
        var list = new List<int>();
        var cache = new Cache<Local>();
        cache.MaxCacheSize = 1;
        cache.MaxTimeSeconds = 0;

        cache.Add(1, new Local(3, list));

        GC.Collect();

        Assert.AreEqual(list, new List<int> { 3 });
    }
}
