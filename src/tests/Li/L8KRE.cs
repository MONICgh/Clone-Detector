using NUnit.Framework;

namespace RepeatString
{
    internal class RepeatStringTest
    {
        [Test]
        public void Test1()
        {
            Assert.IsTrue(Substring.LongestRepeatSubstring("mask4cask") == "ask");
        }

        [Test]
        public void Test2()
        {
            Assert.IsTrue(Substring.LongestRepeatSubstring("abcd") == "");
        }

        [Test]
        public void Test3()
        {
            Assert.IsTrue(Substring.LongestRepeatSubstring("gfadsgkaabbccaabbccaajkgds") == "aabbccaa");
        }
    }
}
