using System.Collections;
using System.Collections.Generic;

namespace MyLinkedList
{
    public class Node<T>
    {
        public T val;
        public Node<T> next;

        public Node(T x)
        {
            val = x;
        }
    }
    
    public class MyLinkedList<T> : IEnumerable<T>
    {
        private Node<T> _begin, _end;
        public int Count { get; private set; }

        public void Push(T elem)
        {
            var node = new Node<T>(elem);
            if (_begin == null)
            {
                _begin = node;
                _end = node;
            }
            else
            {
                _end.next = node;
                _end = node;
            }
            
            _end = node;
            ++Count;
        }

        public bool Erase(T elem)
        {
            var cur = _begin;
            Node<T> prev = null;
            while (cur != null)
            {
                if (cur.val.Equals(elem))
                {
                    if (Count == 1)
                    {
                        _begin = null;
                        _end = null;
                    } 
                    else if (prev == null)
                    {
                        _begin = _begin.next;
                    }
                    else if (cur.next == null)
                    {
                        _end = prev;
                    }
                    else
                    {
                        prev.next = cur.next;
                    }

                    --Count;
                    return true;
                }

                prev = cur;
                cur = cur.next;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var cur = _begin;
            while (cur != null)
            {
                yield return cur.val;
                cur = cur.next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}