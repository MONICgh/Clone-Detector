using NUnit.Framework;

namespace MaxMin;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var expected = new ulong[] { 42310, 10342 };
        var actual = MaxiMinni.MaxMin(12340);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test2()
    {
        var expected = new ulong[] { 98761, 18769 };
        var actual = MaxiMinni.MaxMin(98761);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test3()
    {
        var expected = new ulong[] { 9000, 9000 };
        var actual = MaxiMinni.MaxMin(9000);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test4()
    {
        var expected = new ulong[] { 31121, 11123 };
        var actual = MaxiMinni.MaxMin(11321);
        Assert.AreEqual(expected, actual);
    }
}