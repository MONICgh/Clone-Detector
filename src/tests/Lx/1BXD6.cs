using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack
{
    public class Stack
    {
        private List<int> _items = new List<int>();

        public int Count => _items.Count;


        public void Push(int item)
        {

            _items.Add(item);
        }

        public int Pop()
        {
            var item = _items.LastOrDefault();

            
            _items.RemoveAt(_items.Count - 1);

            return item;
        }


        public int Peek()
        {
            var item = _items.LastOrDefault();

            return item;
        }

        public int MinValue()
        {
            var item = _items.Min();

            return item;
        }
    }
}