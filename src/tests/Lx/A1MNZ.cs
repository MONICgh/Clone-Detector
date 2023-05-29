using System;
using System.Collections.Generic;

namespace MinStack
{
    public class MinStack<T> where T : IComparable<T>
    {
        private readonly Stack<T> _stack;
        private readonly Stack<T> _mins;
        private int _size;

        private void CheckEmpty()
        {
            if (_size == 0)
            {
                throw new Exception("Stack is empty");
            }
        }

        public MinStack()
        {
            _stack = new Stack<T>();
            _mins = new Stack<T>();
            _size = 0;
        }

        public void Push(T elem)
        {
            if (_size == 0 || elem.CompareTo(_mins.Peek()) <= 0)
            {
                _mins.Push(elem);
            }
            else
            {
                _mins.Push(_mins.Peek());
            }

            _stack.Push(elem);
            _size += 1;
        }

        public T Pop()
        {   
            CheckEmpty();
            _mins.Pop();
            _size -= 1;
            return _stack.Pop();
        }

        public T Min()
        {   
            CheckEmpty();
            return _mins.Peek();
        }

        public T Peek()
        {
            CheckEmpty();
            return _stack.Peek();
        }

        public int Size()
        {
            return _size;
        }
    }
}