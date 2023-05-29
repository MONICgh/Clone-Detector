using NUnit.Framework;
using FibonacciString;

namespace Tests.FibonacciStringTests
{
    [TestFixture]
    public class Tests
    {
        private Solver solver = new Solver();
        
        [Test]
        public void Test1()
        {
            Assert.True(solver.StringyFib(1) == "invalid");
        }

        [Test]
        public void Test2()
        {
            Assert.True(solver.StringyFib(3) == "b, a, ab");
        }

        [Test]
        public void Test3()
        {
            Assert.True(solver.StringyFib(7) == "b, a, ab, aba, abaab, abaababa, abaababaabaab");
        }
    }
}