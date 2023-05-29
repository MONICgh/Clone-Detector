using NUnit.Framework;

namespace HW_06.LinkedList;

public class Test
{
    [Test]
    public void Test1()
    {
        var list = new LinkedListImpl<int> { 5, 6, 7 };

        Assert.AreEqual(new List<int> { 5, 6, 7 }, list.ToList());
        Assert.AreEqual(3, list.Count);

        list.Add(8);
        Assert.AreEqual(4, list.Count);

        Assert.True(list.Remove(5));
        Assert.False(list.Remove(-1));

        Assert.AreEqual(3, list.Count);
    }


}
