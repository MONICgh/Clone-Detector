using System.Collections;

namespace Task3;

public class MyLinkedList<T> : IEnumerable<T>
{
    private class MyListNode
    {
        public T Elem; 
        public MyListNode? Next;

        public MyListNode(T el)
        {
            Elem = el;
            Next = null;
        }
    }

    private MyListNode? _first = null;
    private MyListNode? _last = null;
    public int Count { get; private set; } = 0;

    public IEnumerator<T> GetEnumerator()
    {
        var cur = _first;
        while (cur != null)
        {
            yield return cur.Elem;
            cur = cur.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void AddLast(T el)
    {
        var node = new MyListNode(el);
        if (_first == null || _last == null)
        {
            _first = node;
            _last = node;
        }
        else
        {
            _last.Next = node;
            _last = node;
        }
        
        Count++;
    }

    public bool Remove(T el)
    {
        var cur = _first;
        MyListNode? prev = null;
        while (cur != null)
        {
            if (cur.Elem.Equals(el))
            {
                if (prev == null)
                {
                    _first = cur.Next;
                }
                else
                {
                    prev.Next = cur.Next;
                }

                Count--;
                return true;
            }

            prev = cur;
            cur = cur.Next;
        }

        return false;
    }
}