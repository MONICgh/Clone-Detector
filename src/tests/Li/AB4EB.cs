using NUnit.Framework;
using RepeatingSubstring;

namespace Tests.RepeatingSubstringTests
{
    [TestFixture]
    public class Tests
    {
        private Solver solver = new Solver();
        
        [Test]
        public void Test1()
        {
            Assert.True(solver.Solve("mask4cask") == "ask");
        }

        [Test]
        public void Test2()
        {
            Assert.True(solver.Solve("abcd") == "");
        }

        [Test]
        public void Test3()
        {
            Assert.True(solver.Solve("aaaaaa") == "aaaaa");
        }
    }
}