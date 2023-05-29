using NUnit.Framework;
using StringSort;

namespace Tests.StringSortTests
{
    [TestFixture]
    public class Tests
    {
        private Solver solver = new Solver();
        
        [Test]
        public void Test1()
        {
            Assert.True(solver.Sorting("eA2a1E") == "aAeE12");
        }

        [Test]
        public void Test2()
        {
            Assert.True(solver.Sorting("Re4r") == "erR4");
        }

        [Test]
        public void Test3()
        {
            Assert.True(solver.Sorting("6jnM31Q") == "jMnQ136");
        }
        
        [Test]
        public void Test4()
        {
            Assert.True(solver.Sorting("846ZIbo") == "bIoZ468");
        }
    }
}