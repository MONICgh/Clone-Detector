using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedList;

public class LinkedList<T> : IEnumerable<T>
{
    private ListNode<T> _head;
    private ListNode<T> _tail;
    private int _length;

    public int Count => _length;

    public LinkedList()
    {
        _head = new ListNode<T>();
        _tail = new ListNode<T>();
        _head.Next = _tail;
        _tail.Previous = _head;
    }

    public void AddLast(T newElement)
    {
        var newNode = new ListNode<T>(newElement, _tail, _tail.Previous!);
        _tail.Previous!.Next = newNode;
        _tail.Previous = newNode;
        
        _length += 1;
    }

    public bool Remove(T element)
    {
        var node = _head;
        while (node != null)
        {
            if (Equals(node.Value, element))
            {
                node.Previous!.Next = node.Next;
                node.Next!.Previous = node.Previous;
                _length -= 1;
                return true;
            }

            node = node.Next;
        }

        return false;
    }
    
    public IEnumerator<T> GetEnumerator()
    {
        var node = _head.Next;
        while (node != _tail)
        {
            if (node.Value is null)
            {
                throw new Exception("Element cannot be null");
            }
            yield return node.Value;
            node = node.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

internal class ListNode<T>
{
    public ListNode<T>? Previous;
    public ListNode<T>? Next;
    public T? Value;

    public ListNode()
    {
        Previous = null;
        Next = null;
        Value = default;
    }

    public ListNode(T value, ListNode<T> next, ListNode<T> previous)
    {
        Value = value;
        Next = next;
        Previous = previous;
    }
}