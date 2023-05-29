using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace LinkedList;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var list = new LinkedList<int>();
        list.AddLast(1);
        list.AddLast(2);
        list.AddLast(3);
        list.AddLast(4);
        list.AddLast(1);
        
        Assert.AreEqual(5, list.Count);

        Assert.True(list.Remove(1));
        Assert.False(list.Remove(239));
        
        Assert.AreEqual(4, list.Count);

        var correctList = new List<int> { 2, 3, 4, 1 };
        var newList = list.ToList();

        Assert.AreEqual(correctList, newList);
    }
}