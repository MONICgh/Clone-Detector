using NUnit.Framework;

namespace Fraction
{
    internal class FractionTest
    {
        [Test]
        public void Test1()
        {
            Assert.IsTrue(Fraction.Simplify("4/6") == "2/3");
        }

        [Test]
        public void Test2()
        {
            Assert.IsTrue(Fraction.Simplify("10/11") == "10/11");
        }

        [Test]
        public void Test3()
        {
            Assert.IsTrue(Fraction.Simplify("100/400") == "1/4");
        }

        [Test]
        public void Test4()
        {
            Assert.IsTrue(Fraction.Simplify("8/4") == "2");
        }

        [Test]
        public void Test5()
        {
            Assert.IsTrue(Fraction.Simplify("36/24") == "3/2");
        }
    }
}
