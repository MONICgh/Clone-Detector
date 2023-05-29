using NUnit.Framework;

namespace HW_05.Factorizer;

[TestFixture]
public class TestFactorize
{
    [Test]
    public void Check()
    {
        Assert.AreEqual("2 x 5", Factorizer.Factorize(10));
        Assert.AreEqual("2", Factorizer.Factorize(2));
        Assert.AreEqual("2^2", Factorizer.Factorize(4));
        Assert.AreEqual("2^2 x 3 x 5", Factorizer.Factorize(60));
    }
}
