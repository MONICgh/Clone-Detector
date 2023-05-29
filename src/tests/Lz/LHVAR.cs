using Pseudo_Stack;
using NUnit.Framework;

namespace Tests.PseudoStackTests
{   
    [TestFixture]
    public class PseudoStackTests
    {
        [Test]
        public void PushAndPeekTest()
        {
            var minStack = new PseudoStack<int>();
            const int N = 1000;
            for (var i = 0; i < N; ++i)
            {
                minStack.Push(i);
                Assert.True(i == minStack.Peek());
            }
        }

        [Test]
        public void PopTest()
        {
            var minStack = new PseudoStack<int>();
            const int N = 1000;
            for (var i = 0; i < N; ++i)
            {
                minStack.Push(i);
            }
            for (var i = N - 1; i >= 0; --i)
            {
                Assert.True(i == minStack.Pop());
            }
        }

        [Test]
        public void SizeTest()
        {
            var minStack = new PseudoStack<int>();
            const int N = 1000;
            for (var i = 0; i < N; ++i)
            {
                minStack.Push(i);
                Assert.True(i + 1 == minStack.Size());
            }
            for (var i = N - 1; i >= 0; --i)
            {
                minStack.Pop();
                Assert.True(i == minStack.Size()); 
            }
        }
    }
}