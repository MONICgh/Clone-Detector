using NUnit.Framework;

namespace Rational;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase(2, 5 , "0.4")]
    [TestCase(1, 6 , "0.1(6)")]
    [TestCase(1, 3 , "0.(3)")]
    [TestCase(1, 7 , "0.(142857)")]
    [TestCase(1, 77, "0.(012987)" )]
    public void TestRationalNumbers(int a, int b, string expected)
    {
        Assert.AreEqual(expected, RationalNumber.Rational(a, b));
    }
}