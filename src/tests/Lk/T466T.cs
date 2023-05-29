using NUnit.Framework;
using LuckyTickets;

namespace Tests.LuckyTicketsTests
{
    [TestFixture]
    public class Tests
    {   
        LuckyTicketsCounter solver = new LuckyTicketsCounter();
        
        [Test]
        public void Test1()
        {
            Assert.True(solver.Count(2) == 10);
        }
        
        [Test]
        public void Test2()
        {
            Assert.True(solver.Count(4) == 670);
        }
        
        [Test]
        public void Test3()
        {
            Assert.True(solver.Count(12) == 39581170420);
        }
    }
}