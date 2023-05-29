using NUnit.Framework;

namespace SortString
{
    internal class SortStringTest
    {
        [Test]
        public void Test1()
        {
            Assert.IsTrue(Sorting.sortString("eA2a1E") == "aAeE12");
        }

        [Test]
        public void Test2()
        {
            Assert.IsTrue(Sorting.sortString("Re4r") == "erR4");
        }

        [Test]
        public void Test3()
        {
            Assert.IsTrue(Sorting.sortString("6jnM31Q") == "jMnQ136");
        }

        [Test]
        public void Test4()
        {
            Assert.IsTrue(Sorting.sortString("846ZIbo") == "bIoZ468");
        }
    }
}
