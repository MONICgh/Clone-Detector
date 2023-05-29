using NUnit.Framework;

namespace TwoList
{
    internal class TwoListTest
    {
        [Test]
        public void Test1()
        {
            Node<int> A = new Node<int>(5, null);
            Node<int> B = new Node<int>(6, A);
            Node<int> C = new Node<int>(7, B);
            Node<int> D = new Node<int>(8, A);

            LinkedList<int> list1 = new LinkedList<int>(C);
            LinkedList<int> list2 = new LinkedList<int>(D);

            Assert.IsTrue(LinkedList<int>.FindIntersection(list1, list2) == A);
        }

        [Test]
        public void Test2()
        {
            Node<int> A = new Node<int>(5, null);
            Node<int> B = new Node<int>(6, A);
            Node<int> C = new Node<int>(7, B);
            Node<int> D = new Node<int>(8, C);

            LinkedList<int> list1 = new LinkedList<int>(B);
            LinkedList<int> list2 = new LinkedList<int>(D);

            Assert.IsTrue(LinkedList<int>.FindIntersection(list1, list2) == B);
        }

        [Test]
        public void Test3()
        {
            Node<int> A = new Node<int>(5, null);
            Node<int> B = new Node<int>(6, A);
            Node<int> C = new Node<int>(7, B);
            Node<int> D = new Node<int>(8, null);
            Node<int> E = new Node<int>(9, D);
            Node<int> F = new Node<int>(10, E);

            LinkedList<int> list1 = new LinkedList<int>(C);
            LinkedList<int> list2 = new LinkedList<int>(F);

            Assert.IsTrue(LinkedList<int>.FindIntersection(list1, list2) == null);
        }

        [Test]
        public void Test4()
        {
            Node<int> A = new Node<int>(5, null);
            Node<int> B = new Node<int>(6, A);
            Node<int> C = new Node<int>(7, B);
            Node<int> D = new Node<int>(8, B);
            Node<int> E = new Node<int>(9, D);
            Node<int> F = new Node<int>(10, E);

            LinkedList<int> list1 = new LinkedList<int>(C);
            LinkedList<int> list2 = new LinkedList<int>(F);

            Assert.IsTrue(LinkedList<int>.FindIntersection(list1, list2) == B);
        }

        [Test]
        public void Test5()
        {
            Node<int> A = new Node<int>(5, null);
            Node<int> B = new Node<int>(6, A);
            Node<int> C = new Node<int>(7, B);

            LinkedList<int> list1 = new LinkedList<int>(C);
            LinkedList<int> list2 = new LinkedList<int>(null);

            Assert.IsTrue(LinkedList<int>.FindIntersection(list1, list2) == null);
        }

        [Test]
        public void Test6()
        {
            LinkedList<int> list1 = new LinkedList<int>(null);
            LinkedList<int> list2 = new LinkedList<int>(null);

            Assert.IsTrue(LinkedList<int>.FindIntersection(list1, list2) == null);
        }
    }
}
