using NUnit.Framework;

namespace Delegates
{
    internal class DelegatesTest
    {
        static readonly double EPS = 1e-6;

        [Test]
        public void Test1()
        {
            Assert.IsTrue(Math.Abs(Program.Integrate((x) => x, 0, 2) - 2) < EPS);
        }

        [Test]
        public void Test2()
        {
            Assert.IsTrue(Math.Abs(Program.Integrate((x) => x * x, 1, 4) - 21) < EPS);
        }

        [Test]
        public void Test3()
        {
            Assert.IsTrue(Math.Abs(Program.Integrate((x) => Math.Abs(x), -1, 1) - 1) < EPS);
        }
    }
}
