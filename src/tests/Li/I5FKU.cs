using NUnit.Framework;

namespace OneSymbolDiff
{
    internal class OneSymbolDiffTest
    {
        [Test]
        public void Test1()
        {
            Assert.IsTrue(OneSymbolDiff.oneSymbolDiff("aboba", "aoba"));
        }

        [Test]
        public void Test2()
        {
            Assert.IsTrue(OneSymbolDiff.oneSymbolDiff("aboba", "abcba"));
        }

        [Test]
        public void Test3()
        {
            Assert.IsFalse(OneSymbolDiff.oneSymbolDiff("aboa", "aoba"));
        }

        [Test]
        public void Test4()
        {
            Assert.IsTrue(OneSymbolDiff.oneSymbolDiff("aaaaaa", "aaaaa"));
        }

        [Test]
        public void Test5()
        {
            Assert.IsTrue(OneSymbolDiff.oneSymbolDiff("aaaaa", "aaaaa"));
        }
    }
}
