using NUnit.Framework;
using Mailboxes;

namespace Tests.MailboxesTests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var solver = new Solver(new int[] {1, 4, 8, 10, 20}, 3);
            Assert.True(solver.Solve() == 5);
        }
        
        [Test]
        public void Test2()
        {
            var solver = new Solver(new int[] {2, 3, 5, 12, 18}, 2);
            Assert.True(solver.Solve() == 9);
        }
        
        [Test]
        public void Test3()
        {
            var solver = new Solver(new int[] {7, 6, 4, 1}, 1);
            Assert.True(solver.Solve() == 8);
        }
        
        [Test]
        public void Test4()
        {
            var solver = new Solver(new int[] {3, 6, 14, 10}, 4);
            Assert.True(solver.Solve() == 0);
        }
    }
}