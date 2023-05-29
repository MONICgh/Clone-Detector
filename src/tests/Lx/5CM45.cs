using NUnit.Framework;

namespace StackMin
{
    internal class StackMinTest
    {
        [Test]
        public void Test1()
        {
            StackMin stack = new StackMin();
            stack.Push(1);
            Assert.IsTrue(stack.MinValue() == 1);
            Assert.IsTrue(stack.Top() == 1);
            stack.Push(5);
            Assert.IsTrue(stack.MinValue() == 1);
            Assert.IsTrue(stack.Top() == 5);
            stack.Push(3);
            Assert.IsTrue(stack.MinValue() == 1);
            Assert.IsTrue(stack.Top() == 3);
            stack.Pop();
            Assert.IsTrue(stack.MinValue() == 1);
            Assert.IsTrue(stack.Top() == 5);
        }

        [Test]
        public void Test2()
        {
            StackMin stack = new StackMin();
            stack.Push(10);
            Assert.IsTrue(stack.MinValue() == 10);
            Assert.IsTrue(stack.Top() == 10);
            stack.Push(8);
            Assert.IsTrue(stack.MinValue() == 8);
            Assert.IsTrue(stack.Top() == 8);
            stack.Push(5);
            Assert.IsTrue(stack.MinValue() == 5);
            Assert.IsTrue(stack.Top() == 5);
            stack.Pop();
            Assert.IsTrue(stack.MinValue() == 8);
            Assert.IsTrue(stack.Top() == 8);
            stack.Push(9);
            Assert.IsTrue(stack.MinValue() == 8);
            Assert.IsTrue(stack.Top() == 9);
            stack.Push(4);
            Assert.IsTrue(stack.MinValue() == 4);
            Assert.IsTrue(stack.Top() == 4);
            stack.Push(17);
            Assert.IsTrue(stack.MinValue() == 4);
            Assert.IsTrue(stack.Top() == 17);
            stack.Pop();
            Assert.IsTrue(stack.MinValue() == 4);
            Assert.IsTrue(stack.Top() == 4);
            stack.Push(10);
            Assert.IsTrue(stack.MinValue() == 4);
            Assert.IsTrue(stack.Top() == 10);
        }
    }
}
