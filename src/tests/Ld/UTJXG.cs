using NUnit.Framework;

namespace SimplifySpace;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        Assert.AreEqual("2/3", Program.Simplify("4/6"));
    }
    
    [Test]
    public void Test2()
    {
        Assert.AreEqual("10/11", Program.Simplify("10/11"));
    }
    
    [Test]
    public void Test3()
    {
        Assert.AreEqual("1/4", Program.Simplify("100/400"));
    }
    
    [Test]
    public void Test4()
    {
        Assert.AreEqual("2", Program.Simplify("8/4"));
    }
}