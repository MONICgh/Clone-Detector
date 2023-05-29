using System.Collections;

namespace LinkedList
{
    public class MyLinkedList<T> : IEnumerable<T>
    {
        private int count = 0;
        public int Count
        {
            get
            {
                return count;
            }
        }
        private Node<T>? head = null;

        public MyLinkedList() { }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T>? curNode = head;
            while (curNode != null)
            {
                yield return curNode.Data;
                curNode = curNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            count++;
            if (head == null)
            {
                head = new Node<T>(item);
                return;
            }

            Node<T> curNode = head;
            while (curNode.Next != null)
            {
                curNode = curNode.Next;
            }
            curNode.Next = new Node<T>(item);
        }

        public bool Remove(T item)
        {
            Node<T>? curNode = head;
            Node<T>? prevNode = null;
            while (curNode != null)
            {
                if ((curNode.Data == null && item == null) || (curNode.Data != null && curNode.Data.Equals(item)))
                {
                    if (prevNode == null)
                    {
                        head = curNode.Next;
                    }
                    else
                    {
                        prevNode.Next = curNode.Next;
                    }
                    count--;
                    return true;
                }
                prevNode = curNode;
                curNode = curNode.Next;
            }
            return false;
        }
    }
}