using System.Collections;

namespace MyLinkedList;

public class MyLinkedList<T> : IEnumerable<T>
{
    private Node<T>? _head;
    private Node<T>? _tail;
    
    public int Count { get; private set; }

    public MyLinkedList()
    {
        _head = null;
        _tail = null;
        Count = 0;
    }

    public void Add(T value)
    {
        var node = new Node<T>(value);
        
        if (_tail == null)
        {
            _head = node;
            _tail = node;
        }
        else
        {
            _tail.Next = node;
            _tail.Next.Prev = _tail;
            _tail = _tail.Next;
        }

        Count += 1;
    }

    public bool Remove(T value)
    {
        var curNode = _head;
        while (curNode != null && !EqualityComparer<T>.Default.Equals(curNode.Value, value))
        {
            curNode = curNode.Next;
        }

        if (curNode == null) return false;

        if (curNode.Prev != null)
        {
            curNode.Prev.Next = curNode.Next;
        }
        else
        {
            _head = curNode.Next;
        }

        if (curNode.Next != null)
        {
            curNode.Next.Prev = curNode.Prev;
        }
        else
        {
            _tail = curNode.Prev;
        }

        Count -= 1;
        
        return true;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var curNode = _head;
        while (curNode != null)
        {
            yield return curNode.Value;
            curNode = curNode.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}