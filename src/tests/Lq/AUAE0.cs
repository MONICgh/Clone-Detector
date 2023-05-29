using NUnit.Framework;

namespace HW_12;

[TestFixture]
public class Tests
{
    [Test]
    public void Test()
    {
        Assert.AreEqual(TaskCar.Solve(6), "AAARA");
        Assert.AreEqual(TaskCar.Solve(3), "AA");
    }
}
