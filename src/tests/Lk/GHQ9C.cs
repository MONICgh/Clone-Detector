using NUnit.Framework;

namespace LuckyTicket
{
    internal class LuckyTicketTest
    {
        [Test]
        public void Test1()
        {
            Assert.IsTrue(LuckyTicket.NumLuckyTicket(2) == 10);
        }

        [Test]
        public void Test2()
        {
            Assert.IsTrue(LuckyTicket.NumLuckyTicket(4) == 670);
        }

        [Test]
        public void Test3()
        {
            Assert.IsTrue(LuckyTicket.NumLuckyTicket(12) == 39581170420);
        }
    }
}
