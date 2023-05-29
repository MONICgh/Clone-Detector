using NUnit.Framework;

namespace MailBox
{
    internal class StreetTest
    {
        [Test]
        public void Test1()
        {
            Assert.True(new Street(new int[] { 20, 1, 8, 4, 10 }).ArrangeMailBoxesAndGetMinDistance(3) == 5);
        }

        [Test]
        public void Test2()
        {
            Assert.True(new Street(new int[] { 12, 3, 18, 2, 5 }).ArrangeMailBoxesAndGetMinDistance(2) == 9);
        }

        [Test]
        public void Test3()
        {
            Assert.True(new Street(new int[] { 7, 4, 6, 1 }).ArrangeMailBoxesAndGetMinDistance(1) == 8);
        }

        [Test]
        public void Test4()
        {
            Assert.True(new Street(new int[] { 3, 6, 14, 10 }).ArrangeMailBoxesAndGetMinDistance(4) == 0);
        }
    }
}
