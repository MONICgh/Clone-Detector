using System.Collections;

namespace HW_06.LinkedList;

public class LinkedListImpl<T> : IEnumerable<T>
{
    private struct EnumeratorLinkedList<TE> : IEnumerator<TE>
    {
        private readonly LinkedListImpl<TE> _list;
        private LinkedListImpl<TE>.Node<TE>? _nextNode;

        public EnumeratorLinkedList(LinkedListImpl<TE> list)
        {
            this._list = list;
            _nextNode = list._head;
            Current = default(TE);
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (_nextNode == null)
                return false;
            Current = _nextNode.Value;
            _nextNode = _nextNode.Next;
            return true;
        }

        public TE? Current { get; private set; }

        object? IEnumerator.Current { get { return Current; } }

        void IEnumerator.Reset()
        {
            _nextNode = _list._head;
            Current = default(TE);
        }
    }

    public int Count { get; private set; }
    private Node<T>? _head;
    public void Add(T value)
    {
        if (_head == null)
        {
            _head = new Node<T>(value);
        }
        else
        {
            var current = _head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = new Node<T>(value);
        }
        Count++;
    }

    public bool Remove(T value)
    {
        if (_head == null)
            return false;
        if (_head.Value!.Equals(value))
        {
            _head = _head.Next;
            Count--;
            return true;
        }
        var current = _head.Next;
        var prev = _head;
        while (current != null)
        {
            if (current.Value!.Equals(value))
            {
                prev.Next = current.Next;
                Count--;
                return true;
            }
            prev = current;
            current = current.Next;
        }
        return false;
    }

    private class Node<TN>
    {
        public Node<TN>? Next;
        public TN Value;

        public Node(TN value)
        {
            Next = null;
            Value = value;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new EnumeratorLinkedList<T>(this);
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
