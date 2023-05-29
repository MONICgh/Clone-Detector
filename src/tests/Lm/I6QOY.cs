using NUnit.Framework;

namespace HW_06.Lake;

public class Test
{
    [Test]
    public void Test1()
    {
        var input = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        var lake = new Lake(input);
        var list = lake.ToList();
        Assert.AreEqual(list, new List<int>
        {
            1, 3, 5, 7, 9, 8, 6, 4, 2
        });
    }

    [Test]
    public void Test2()
    {
        var input = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };

        var lake = new Lake(input);
        var list = lake.ToList();
        Assert.AreEqual(list, new List<int>
        {
            1, 3, 5, 7, 8, 6, 4, 2
        });
    }
}
