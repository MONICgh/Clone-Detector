using NUnit.Framework;

namespace HW_11;

[TestFixture]
public class TestBus
{
    [Test]
    public void Check()
    {
        var result = Buses.Solve(new List<List<int>>
        {
            new() { 1, 2, 7 },
            new() { 3, 6, 7 }
        }, 1, 6);

        Assert.AreEqual(2, result);
    }
}
