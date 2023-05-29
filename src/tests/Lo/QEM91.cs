using NUnit.Framework;

namespace HW_14;

[TestFixture]
public class Test
{
    [Test]
    public void TestRace()
    {
        RaceExample cl = new RaceExample();
        Assert.AreNotEqual(cl.Run1(), cl.Run2());
    }

    [Test]
    public void TestFirstSecondThird()
    {
        OrderedWriter writer = new OrderedWriter();
        var data = writer.getResult(new List<int> { 2, 1, 0 });
        Assert.AreEqual("firstsecondthird", data);
    }
}
