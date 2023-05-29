using NUnit.Framework;

namespace Factor;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        Assert.AreEqual("2", Factor.ExpressFactor(2));
    }

    [Test]
    public void Test2()
    {
        Assert.AreEqual("2^2", Factor.ExpressFactor(4));
    }

    [Test]
    public void Test3()
    {
        Assert.AreEqual("2 x 5", Factor.ExpressFactor(10));
    }

    [Test]
    public void Test4()
    {
        Assert.AreEqual("2^2 x 3 x 5", Factor.ExpressFactor(60));
    }
}