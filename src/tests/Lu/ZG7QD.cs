using NUnit.Framework;

namespace Rational
{
    internal class PeriodTest
    {
        [Test]
        public void Test1()
        {
            Assert.IsTrue(Period.Rational(2, 5) == "0.4");
        }

        [Test]
        public void Test2()
        {
            Assert.IsTrue(Period.Rational(1, 6) == "0.1(6)");
        }

        [Test]
        public void Test3()
        {
            Assert.IsTrue(Period.Rational(1, 3) == "0.(3)");
        }

        [Test]
        public void Test4()
        {
            Assert.IsTrue(Period.Rational(1, 7) == "0.(142857)");
        }

        [Test]
        public void Test5()
        {
            Assert.IsTrue(Period.Rational(1, 77) == "0.(012987)");
        }

        [Test]
        public void Test6()
        {
            Assert.IsTrue(Period.Rational(110809, 900000) == "0.12312(1)");
        }

        [Test]
        public void Test7()
        {
            Assert.IsTrue(Period.Rational(37, 64) == "0.578125");
        }
    }
}
