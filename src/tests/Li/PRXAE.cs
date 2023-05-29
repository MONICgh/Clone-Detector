using NUnit.Framework;

namespace FibonacciStrings
{
    internal class FibonacciStringsTest
    {
        [Test]
        public void Test1()
        {
            Assert.IsTrue(Fibonacci.FibonacciBuild(1) == "invalid");
        }

        [Test]
        public void Test2()
        {
            Assert.IsTrue(Fibonacci.FibonacciBuild(3) == "b, a, ab");
        }

        [Test]
        public void Test3()
        {
            Assert.IsTrue(Fibonacci.FibonacciBuild(7) == "b, a, ab, aba, abaab, abaababa, abaababaabaab");
        }
    }
}
