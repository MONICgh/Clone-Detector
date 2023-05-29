using System;
using System.Collections.Generic;
using System.Linq;
using MinStack;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class MinStackTests
    {
        [Test]
        public void PushAndPeekTest()
        {
            var minStack = new MinStack<int>();
            const int N = 1000;
            for (var i = 0; i < N; ++i)
            {
                minStack.Push(i);
                Assert.IsTrue(i == minStack.Peek());
            }
        }

        [Test]
        public void PopTest()
        {
            var minStack = new MinStack<int>();
            const int N = 1000;
            for (var i = 0; i < N; ++i)
            {
                minStack.Push(i);
            }
            for (var i = N - 1; i >= 0; --i)
            {
                Assert.IsTrue(i == minStack.Pop());
            }
        }

        [Test]
        public void SizeTest()
        {
            var minStack = new MinStack<int>();
            const int N = 1000;
            for (var i = 0; i < N; ++i)
            {
                minStack.Push(i);
                Assert.IsTrue(i + 1 == minStack.Size());
            }
            for (var i = N - 1; i >= 0; --i)
            {
                minStack.Pop();
                Assert.IsTrue(i == minStack.Size()); 
            }
        }

        [Test]
        public void MinTest()
        {
            var minStack = new MinStack<int>();
            const int N = 1000;
            var stack = new Stack<int>();
            var rng = new Random();
            for (var i = 0; i < N; ++i)
            {
                var r = rng.Next(0, 1);
                if (minStack.Size() == 0 || r == 0)
                {
                    var elem = rng.Next();
                    minStack.Push(elem);
                    stack.Push(elem);
                }
                else
                {
                    Assert.IsTrue(minStack.Size() > 0);
                    minStack.Pop();
                    stack.Pop();
                }

                if (minStack.Size() > 0)
                {
                    Assert.IsTrue(minStack.Min() == stack.Min());
                }
            }
        }
    }
}