using NUnit.Framework;

namespace Matryoshka
{
    internal class MatryoshkaTest
    {
        [Test]
        public void Test1()
        {
            Envelope e1 = new(5, 4);
            Envelope e2 = new(6, 4);
            Envelope e3 = new(6, 7);
            Envelope e4 = new(2, 3);
            Assert.IsTrue(Envelope.MaxMatryoshka(new Envelope[] { e1, e2, e3, e4 }) == 3);
        }

        [Test]
        public void Test2()
        {
            Envelope e1 = new(1, 1);
            Envelope e2 = new(1, 1);
            Envelope e3 = new(1, 1);
            Assert.IsTrue(Envelope.MaxMatryoshka(new Envelope[] { e1, e2, e3 }) == 1);
        }
    }
}
