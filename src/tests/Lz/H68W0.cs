using NUnit.Framework;

namespace PseudoStack
{
    internal class PseudoStackTest
    {
        [Test]
        public void Test1()
        {
            PseudoStack<int> st = new PseudoStack<int>(2);
            st.Push(5);
            st.Push(7);
            st.Push(17);
            st.Push(1);
            st.Push(8);
            Assert.IsTrue(st.Pop() == 8);
            Assert.IsTrue(st.Pop() == 1);
            Assert.IsTrue(st.Pop() == 17);
            Assert.IsTrue(st.Pop() == 7);
            Assert.IsTrue(st.Pop() == 5);
        }

        [Test]
        public void Test2()
        {
            PseudoStack<int> st = new PseudoStack<int>(1);
            st.Push(1);
            st.Push(2);
            st.Push(3);
            Assert.IsTrue(st.Pop() == 3);
            st.Push(4);
            st.Push(5);
            Assert.IsTrue(st.Pop() == 5);
            st.Push(6);
            Assert.IsTrue(st.Pop() == 6);
            Assert.IsTrue(st.Pop() == 4);
            Assert.IsTrue(st.Pop() == 2);
            st.Push(7);
            Assert.IsTrue(st.Pop() == 7);
            Assert.IsTrue(st.Pop() == 1);
        }

    }
}
