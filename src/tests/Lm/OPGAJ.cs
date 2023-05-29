﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace customLinkedList
{
    public class LinkedList<T> : IEnumerable
    {
        public int Count
        {
            get;
            set;
        }
        // start and end nodes are fictitious to simplify realization
        public Node<T> StartNode;

        public Node<T> EndNode;

        public LinkedList(T value)
        {
            StartNode = new Node<T>(default(T))
            {
                Next = EndNode
            };
            EndNode = new Node<T>(default(T))
            {
                Prev = StartNode
            };
            var newNode = new Node<T>(value);
            StartNode.Next = newNode;
            EndNode.Prev = newNode;

            newNode.Prev = StartNode;
            newNode.Next = EndNode;
            Count++;
        }

        public void Push(T value)
        {
            var newNode = new Node<T>(value)
            {
                Prev = EndNode.Prev
            };
            EndNode.Prev.Next = newNode;
            newNode.Next = EndNode;
            EndNode.Prev = newNode;
            Count++;
        }

        public bool Remove(T value)
        {
            var node = StartNode.Next;
            while (node.Next != EndNode || node.Next != null)
            {
                if (node.Value.Equals(value))
                {
                    var prev = node.Prev;
                    var next = node.Next;
                    prev.Next = next;
                    next.Prev = prev;
                    Count--;
                    return true;
                }

                node = node.Next;
            }

            return false;
        }

        public IEnumerator GetEnumerator()
        {
            return new LinkedListEnum<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class LinkedListEnum<T> : IEnumerator
    {
        public LinkedList<T> List;
        private Node<T> currentNode;

        private int _pos = -1;

        public LinkedListEnum(LinkedList<T> list)
        {
            List = list;
            currentNode = List.StartNode;
        }

        public bool MoveNext()
        {
            if (currentNode.Next == null || currentNode.Next == List.EndNode)
            {
                return false;
            }

            currentNode = currentNode.Next;
            _pos++;
            return (_pos < List.Count);
        }

        public void Reset()
        {
            _pos = -1;
            currentNode = List.StartNode;
        }

        object IEnumerator.Current => Current;

        public Node<T> Current
        {
            get
            {
                try
                {
                    return currentNode;
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }

    public class Node<T>
    {
        public Node<T> Next
        {
            get;
            set;
        }

        public Node<T> Prev
        {
            get;
            set;
        }

        public T Value
        {
            get;
            set;
        }

        public Node(T value)
        {
            Value = value;
        }
    }
}
