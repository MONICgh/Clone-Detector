using System.Collections;
using System.Collections.Generic;

namespace MyLinkedList
{
    public class IEnumerableLinkedList<T> : IEnumerable<Node<T>>
    {
        public int Count;
        public Node<T> Head;
        public Node<T> Tail;

        public IEnumerableLinkedList()
        {
            SetDefaultValues();
        }
        
        public IEnumerableLinkedList(List<T> values)
        {
            SetDefaultValues();
            foreach (var value in values)
            {
                Add(value);
            }
        }

        private void SetDefaultValues()
        {
            Count = 0;
            Head = null;
            Tail = null;
        }

        public void Add(T data)
        {
            if (Count == 0)
            {
                var node = new Node<T>(data);
                Head = node;
                Tail = node;
            }
            else
            {
                var node = new Node<T>(data, next:null, previous: Tail);
                Tail.Next = node;
                Tail = node;
            }

            Count++;
        }

        public bool Remove(T data)
        {
            if (Count == 0)
            {
                return false;
            }

            if (Head.Data.Equals(data))
            {
                var tmpNode = Head.Next;
                Head = tmpNode;
                Head.Previous = null;
                Count--;
                return true;
            }
            
            var current = Head;
            while (current.Next != null)
            {
                if (!current.Data.Equals(data))
                {
                    current = current.Next;
                    continue;
                }
                current.Previous.Next = current.Next;
                current.Next.Previous = current.Previous;
                Count--;
                return true;
            }

            if (current.Data.Equals(data))
            {
                Tail = current.Previous;
                Tail.Next = null;
                Count--;
                return true;
            }

            return false;
        }
        
        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }
        
        public IEnumerator<Node<T>> GetEnumerator()
        {
            var current = Head;
            while (current != null)
            {
                yield return current;
                current = current.Next;
            }
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}