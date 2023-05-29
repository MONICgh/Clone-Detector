using NUnit.Framework;
using StringDistinction;

namespace Tests.StringDistinctionTests
{
    [TestFixture]
    public class Tests
    {
        private Solver solver = new Solver();
        
        [Test]
        public void Test1()
        {
            Assert.True(solver.Check("abde", "abcde"));
        }

        [Test]
        public void Test2()
        {
            Assert.True(solver.Check("aaaaaa", "aaaada"));
        }

        [Test]
        public void Test3()
        {
            Assert.False(solver.Check("aaaaaa", "asgasgasg"));
        }
    }
}