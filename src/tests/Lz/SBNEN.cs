using NUnit.Framework;

namespace Factorization
{
    internal class FactorizationTest
    {
        [Test]
        public void Test1()
        {
            Assert.IsTrue(Factorization.ExpressFactors(2) == "2");
        }

        [Test]
        public void Test2()
        {
            Assert.IsTrue(Factorization.ExpressFactors(4) == "2^2");
        }

        [Test]
        public void Test3()
        {
            Assert.IsTrue(Factorization.ExpressFactors(10) == "2 x 5");
        }

        [Test]
        public void Test4()
        {
            Assert.IsTrue(Factorization.ExpressFactors(60) == "2^2 x 3 x 5");
        }

        [Test]
        public void Test5()
        {
            Assert.IsTrue(Factorization.ExpressFactors(143) == "11 x 13");
        }

        [Test]
        public void Test6()
        {
            Assert.IsTrue(Factorization.ExpressFactors(729) == "3^6");
        }

        [Test]
        public void Test7()
        {
            Assert.IsTrue(Factorization.ExpressFactors(101) == "101");
        }

        [Test]
        public void Test8()
        {
            Assert.IsTrue(Factorization.ExpressFactors(9997) == "13 x 769");
        }

        [Test]
        public void Test9()
        {
            Assert.IsTrue(Factorization.ExpressFactors(121) == "11^2");
        }
    }
}
