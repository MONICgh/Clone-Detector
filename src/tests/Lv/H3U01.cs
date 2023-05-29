using System.Collections.Generic;
using NUnit.Framework;

namespace ThreeSum;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        Assert.AreEqual(ThreeSum.Main(new List<int> { 0, 1, -1, -1, 2 }),
            new List<List<int>> { new() { -1, -1, 2 }, new() { 0, 1, -1 }, new() { 1, -1, 0 } });
    }

    [Test]
    public void Test2()
    {
        Assert.AreEqual(ThreeSum.Main(new List<int> { 0, 0, 0, 5, -5 }),
            new List<List<int>> { new() { 0, 0, 0 }, new() { 0, 5, -5 } });
    }

    [Test]
    public void Test3()
    {
        Assert.AreEqual(ThreeSum.Main(new List<int> { 1, 2, 3 }), new List<List<int>>());
    }

    [Test]
    public void Test4()
    {
        Assert.AreEqual(ThreeSum.Main(new List<int> { 1 }), new List<List<int>>());
    }
}