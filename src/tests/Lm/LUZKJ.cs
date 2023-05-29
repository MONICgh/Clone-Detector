using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Application
{
    class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }

        public T Data { get; set; }

        public Node<T>? Next { get; set; }
    }

    class MyLinkedList<T> : IEnumerable<T> where T: IEquatable<T>
    {
        public Node<T> Head = new Node<T>(default(T));

        private int length = 0;

        public MyLinkedList(List<T> list)
        {
            Node<T> last = Head;
            foreach (T val in list)
            {
                last.Next = new Node<T>(val);
                last = last.Next;
            }
            length = list.Count();
        }

        public void AddLast(T value)
        {
            var node = Head;
            while (node.Next != null)
            {
                node = node.Next;
            }
            node.Next = new Node<T>(value);
            length++;
        }

        public void RemoveLast()
        {
            Node<T>? prevNode = null;
            var node = Head;
            while (node.Next != null)
            {
                prevNode = node;
                node = node.Next;
            }
            if (prevNode == null)
            {
                throw new Exception("list is empty");
            }
            prevNode.Next = null;
            length--;
        }

        public bool Remove(T value)
        {
            
            var node = Head;
            while (node.Next != null)
            {
                if (node.Next.Data.Equals(value))
                {
                    node.Next = node.Next.Next;
                    return true;
                }
                node = node.Next;
            }
            return false;
        }

        public int Count()
        {
            return length;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new MyLinkedListIterator(Head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class MyLinkedListIterator : IEnumerator<T>
        {
            private Node<T> currentNode;
            private Node<T> head;

            public MyLinkedListIterator(Node<T> head)
            {
                this.head = head;
                this.Reset();
            }

            public bool MoveNext()
            {
                currentNode = currentNode.Next;
                return currentNode != null;
            }

            public void Reset() => currentNode = head;

            public T Current => currentNode.Data;

            object IEnumerator.Current => Current;

            public void Dispose() { }
        }
    }

    class Task3
    {
        static void Main()
        {
            var list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
            var linked = new MyLinkedList<int>(list);
            foreach(int item in linked)
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine();

            linked.RemoveLast();
            linked.AddLast(9);
            linked.AddLast(10);
            Console.WriteLine("count: {0}", linked.Count());
            Console.WriteLine("2 removed: {0}", linked.Remove(2));
            Console.WriteLine("2 removed: {0}", linked.Remove(2));
            Console.WriteLine("count: {0}", linked.Count());
            foreach (int item in linked)
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine();
        }
    }
}
