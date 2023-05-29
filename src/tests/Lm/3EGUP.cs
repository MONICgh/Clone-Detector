using NUnit.Framework;

namespace LinkedList
{
    internal class LinkedListTest
    {
        private void checkState<T>(MyLinkedList<T> list, List<T> correct)
        {
            foreach (T elem in list)
            {
                Console.WriteLine(elem);
            }
            Console.WriteLine("----------------");
            List<T> value = new();
            foreach (T item in list)
            {
                value.Add(item);
            }
            Assert.IsTrue(Enumerable.SequenceEqual(value, correct));
        }

        [Test]
        public void Test1()
        {
            MyLinkedList<int> list = new();
            checkState(list, new List<int> { });
            Assert.AreEqual(list.Count, 0);

            list.Add(3);
            list.Add(2);
            list.Add(1);
            list.Add(3);
            checkState(list, new List<int> { 3, 2, 1, 3 });
            Assert.AreEqual(list.Count, 4);

            Assert.IsTrue(list.Remove(3));
            checkState(list, new List<int> { 2, 1, 3 });
            Assert.AreEqual(list.Count, 3);

            Assert.IsTrue(list.Remove(3));
            checkState(list, new List<int> { 2, 1 });
            Assert.AreEqual(list.Count, 2);

            Assert.IsFalse(list.Remove(3));
            Assert.IsTrue(list.Remove(2));
            Assert.IsFalse(list.Remove(5));
            list.Add(5);
            checkState(list, new List<int> { 1, 5 });
            Assert.AreEqual(list.Count, 2);

            Assert.IsTrue(list.Remove(5));
            checkState(list, new List<int> { 1 });
            Assert.AreEqual(list.Count, 1);
        }

        [Test]
        public void Test2()
        {
            MyLinkedList<char> list = new();
            checkState(list, new List<char> { });
            Assert.AreEqual(list.Count, 0);

            list.Add('A');
            list.Add('b');
            list.Add('C');
            list.Add('E');
            checkState(list, new List<char> { 'A', 'b', 'C', 'E' });
            Assert.AreEqual(list.Count, 4);

            Assert.IsTrue(list.Remove('A'));
            Assert.IsFalse(list.Remove('a'));
            checkState(list, new List<char> { 'b', 'C', 'E' });
            Assert.AreEqual(list.Count, 3);

            Assert.IsFalse(list.Remove('B'));
            Assert.IsTrue(list.Remove('b'));
            Assert.IsTrue(list.Remove('E'));
            list.Add('F');
            checkState(list, new List<char> { 'C', 'F' });
            Assert.AreEqual(list.Count, 2);
        }
    }
}
