using NUnit.Framework;

namespace Palindrome
{
    internal class PalindromeTest
    {
        [Test]
        public void Test1()
        {
            Assert.IsTrue(Palindrome.PalSeq(4884) == (69, 4));
        }

        [Test]
        public void Test2()
        {
            Assert.IsTrue(Palindrome.PalSeq(1) == (1, 0));
        }

        [Test]
        public void Test3()
        {
            Assert.IsTrue(Palindrome.PalSeq(11) == (10, 1));
        }

        [Test]
        public void Test4()
        {
            Assert.IsTrue(Palindrome.PalSeq(3113) == (199, 3));
        }

        [Test]
        public void Test5()
        {
            Assert.IsTrue(Palindrome.PalSeq(8836886388) == (177, 15));
        }
    }
}
