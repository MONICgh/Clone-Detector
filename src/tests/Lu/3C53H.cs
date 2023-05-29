using NUnit.Framework;

namespace HW_09.Rationals;

[TestFixture]
public class Test
{
    [Test]
    public void TestRatio()
    {
        
        Assert.AreEqual(Rational.GetSolution(1, 77), "0.(012987)");
        Assert.AreEqual(Rational.GetSolution(2, 5), "0.4");
        Assert.AreEqual(Rational.GetSolution(1, 6), "0.1(6)");
        Assert.AreEqual(Rational.GetSolution(1, 3), "0.(3)");
        Assert.AreEqual(Rational.GetSolution(1, 7), "0.(142857)");

    }
}
