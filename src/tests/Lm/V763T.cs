using NUnit.Framework;

namespace Frog
{
    internal class LakeTest
    {
        [Test]
        public void Test1()
        {
            Lake lake = new(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 });
            List<int> correctOrder = new() { 1, 3, 5, 7, 8, 6, 4, 2 };
            List<int> frogOrder = new();
            foreach (int stone in lake)
            {
                frogOrder.Add(stone);
            }
            Assert.IsTrue(Enumerable.SequenceEqual(frogOrder, correctOrder));
        }

        [Test]
        public void Test2()
        {
            Lake lake = new(new List<int> { 13, 23, 1, -8, 4, 9 });
            List<int> correctOrder = new() { 13, 1, 4, 9, -8, 23 };
            List<int> frogOrder = new();
            foreach (int stone in lake)
            {
                frogOrder.Add(stone);
            }
            Assert.IsTrue(Enumerable.SequenceEqual(frogOrder, correctOrder));
        }

        [Test]
        public void Test3()
        {
            Lake lake = new(new List<int> { -5, 7, 2, 1, 5, 11, 20 });
            List<int> correctOrder = new() { -5, 2, 5, 20, 11, 1, 7 };
            List<int> frogOrder = new();
            foreach (int stone in lake)
            {
                frogOrder.Add(stone);
            }
            Assert.IsTrue(Enumerable.SequenceEqual(frogOrder, correctOrder));
        }

        [Test]
        public void Test4()
        {
            Lake lake = new(new List<int> { 0 });
            List<int> correctOrder = new() { 0 };
            List<int> frogOrder = new();
            foreach (int stone in lake)
            {
                frogOrder.Add(stone);
            }
            Assert.IsTrue(Enumerable.SequenceEqual(frogOrder, correctOrder));
        }
    }
}
