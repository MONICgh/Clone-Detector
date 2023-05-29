using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using static System.Net.Mime.MediaTypeNames;

namespace Lab6
{
    public class Node<T> where T : IComparable
    {
        public Node<T> prev = null;
        public Node<T> next = null;
        public T data { get; set; }

        public Node(T data)
        {
            this.data = data;
        }

        public int Count()
        {
            return next == null ? 1 : next.Count() + 1;
        }

        public void Add(T data)
        {
            if (next != null)
            {
                next.Add(data);
            }
            else
            {
                next = new Node<T>(data);
                next.prev = this;
            }
        }
    }

    public class MyLinkedList<T> : IEnumerable<T> where T : IComparable
    {
        // Invariant: head has no previous element.
        Node<T> head = null;

        public int Count 
        {
            get
            {
                return head == null ? 0 : head.Count();
            }
        }

        public void Add(T data)
        {
            if (head == null)
            {
                head = new Node<T>(data);
                return;
            }
            Node<T> cur = head;
            while (cur.next != null) cur = cur.next;
            cur.next = new Node<T>(data);
            cur.next.prev = cur;
        }

        public bool Remove(T data)
        {
            if (data == null)
                return false;

            if (data.Equals(head.data))
            {
                head = head.next;
                if (head != null)
                {
                    head.prev = null;
                }
                return true;
            }
            else
            {
                Node<T> cur = head;
                while (cur.next != null)
                {
                    if (data.Equals(cur.next.data))
                    {
                        cur.next = cur.next.next;
                        if (cur.next != null)
                            cur.next.prev = cur;
                        return true;
                    }

                    cur = cur.next;
                }
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new MyLinkedListEnumerator<T>(head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class MyLinkedListEnumerator<T> : IEnumerator<T> where T : IComparable
    {
        Node<T> quazi_head;
        Node<T> cur;

        public MyLinkedListEnumerator(Node<T> cur)
        {
            this.quazi_head = new Node<T>(default(T));
            this.quazi_head.next = cur;
            this.cur = quazi_head;
        }

        public T Current
        {
            get
            {
                if(cur == null)
                    throw new ArgumentException();
                return cur.data;
            }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public bool MoveNext()
        {
            if (cur == null || cur.next == null)
                return false;
            cur = cur.next;
            return true;
        }

        public void Reset()
        {
            cur = this.quazi_head;
        }
    }
}
