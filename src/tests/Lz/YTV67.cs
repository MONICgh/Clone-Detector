using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pseudo_Stack
{
    public class PseudoStack<T>
    {
        private readonly int _maxSize;
        private readonly List<Stack<T>> _stacks = new List<Stack<T>>();
        private int _size = 0, _totSize = 0;

        public PseudoStack(int maxSize = 100)
        {
            _maxSize = maxSize;
        }

        public void Push(T item)
        {
            if (_size == 0 || _stacks[_size - 1] .Count == _maxSize)
            {
                ++_size;
                _stacks.Add(new Stack<T>());
            }

            _stacks[_size - 1].Push(item);
            ++_totSize;
        }

        public T Peek()
        {
            if (_totSize == 0)
            {
                throw new InvalidOperationException("The stack is empty!");
            }

            return _stacks[_size - 1].Peek();
        }

        public T Pop()
        {
            if (_totSize == 0)
            {
                throw new InvalidOperationException("The stack is already empty!");
            }

            var res = _stacks[_size - 1].Pop();
            --_totSize;
            if (_stacks[_size - 1].Count == 0)
            {
                --_size;
                _stacks.RemoveAt(_size);
            }

            return res;
        }

        public int Size()
        {
            return _totSize;
        }
    }
}