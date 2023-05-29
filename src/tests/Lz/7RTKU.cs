using NUnit.Framework;

namespace ChaiseLongue
{
    internal class ChaiseLongueTest
    {
        [Test]
        public void Test1()
        {
            Assert.IsTrue(ChaiseLongue.SunLoungers("10001") == 1);
        }

        [Test]
        public void Test2()
        {
            Assert.IsTrue(ChaiseLongue.SunLoungers("00101") == 1);
        }

        [Test]
        public void Test3()
        {
            Assert.IsTrue(ChaiseLongue.SunLoungers("0") == 1);
        }

        [Test]
        public void Test4()
        {
            Assert.IsTrue(ChaiseLongue.SunLoungers("000") == 2);
        }

        [Test]
        public void Test5()
        {
            Assert.IsTrue(ChaiseLongue.SunLoungers("000100110001010000110000") == 5);
        }
    }
}
