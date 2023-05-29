using NUnit.Framework;

namespace DeckChairs;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        Assert.AreEqual(1, DeckChairs.SunLoungers("10001"));
    }
    
    [Test]
    public void Test2()
    {
        Assert.AreEqual(1, DeckChairs.SunLoungers("00101"));
    }
    
    [Test]
    public void Test3()
    {
        Assert.AreEqual(1, DeckChairs.SunLoungers("0"));
    }
    
    [Test]
    public void Test4()
    {
        Assert.AreEqual(1, DeckChairs.SunLoungers("00"));
    }
    
    [Test]
    public void Test5()
    {
        Assert.AreEqual(2, DeckChairs.SunLoungers("000"));
    }
}