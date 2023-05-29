using PrimeFactorization;
using NUnit.Framework;

namespace Tests.PrimeFactorizationTests
{   
    [TestFixture]
    public class PrimeFactorizationTests
    {
        private Factorizer solver = new Factorizer();
        
        [Test]
        public void Test1()
        {
            Assert.True(solver.ExpressFactors(2) == "2");
        }
        
        [Test]
        public void Test2()
        {
            Assert.True(solver.ExpressFactors(4) == "2^2");
        }
        
        [Test]
        public void Test3()
        {
            Assert.True(solver.ExpressFactors(10) == "2 x 5");
        }
        
        [Test]
        public void Test4()
        {
            Assert.True(solver.ExpressFactors(60) == "2^2 x 3 x 5");
        }

        [Test]
        public void BigTest()
        {
            for (var i = 1; i < 10000; ++i)
            {
                var res = solver.FactorizeToList(i);
                var j = 1;
                foreach (var pair in res)
                {
                    for (var it = 0; it < pair.Item2; ++it)
                    {
                        j *= pair.Item1;
                    }
                }
                Assert.True(i == j);
            }
        }
    }
}