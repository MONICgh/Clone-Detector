using System.Collections;
using System.Collections.Generic;

namespace task3
{
    class MyLinkedList<T> : IEnumerable<T>
    {
        private Node<T> _head;
        private Node<T> _tail;
        private Node<T> _startNode;
  
        public int Count { get; private set; }

        public MyLinkedList()
        {
            _startNode = new Node<T>(default(T));

            _head = _startNode;
            _tail = _head;
            Count = 0;
        }

        public void Add(T value)
        {
            var newNode = new Node<T>(value);
            if (_head.Next == null)
            {
                _head.Next = newNode;
            }
            _tail.Next = newNode;
            _tail = newNode;
            Count++;
        }

        public bool Remove(T value)
        {
            var curr = _head;
            while(curr.Next != null)
            {
                if(curr.Next.Value.Equals(value))
                {
                    if (_tail == curr.Next)
                    {
                        _tail = curr;
                    }
                    curr.Next = curr.Next.Next;
                    Count--;
                    return true;
                }
              curr = curr.Next;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var curr = _head;
            while (curr != _tail)
            {
                curr = curr.Next;
                yield return curr.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
