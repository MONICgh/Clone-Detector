using System;
using System.Collections.Generic;

namespace CSdotnet
{
    public class StackMinValue<T> : List<T> where T : IComparable<T>
    {
        private List<T> _collection { get; set; }
        private List<T> _mins;

        public StackMinValue()
        {
            // The internal collection is implemented as an array-based list.
            // See the ArrayList.cs for the list implementation.
            _collection = new List<T>();
            _mins = new List<T>();
        }

        public T MinValue
        {
            get
            {
                try
                {
                    return _mins[_mins.Count - 1];
                }
                catch (Exception)
                {
                    throw new Exception("Stack is empty.");
                }
            }
        }

        public T Top
        {
            get
            {
                try
                {
                    return _collection[_collection.Count - 1];
                }
                catch (Exception)
                {
                    throw new Exception("Stack is empty.");
                }
            }
        }

        public void Push(T dataItem)
        {
            _collection.Add(dataItem);
            if (_collection.Count == 1 || (dataItem.CompareTo(_mins[_mins.Count - 1]) <= 0))
            {
                _mins.Add(dataItem);
            }
        }


        public T Pop()
        {
            try
            {
                var top = _collection[_collection.Count - 1];
                if (top.CompareTo(_mins[_mins.Count - 1]) == 0)
                {
                    _mins.RemoveAt(_mins.Count - 1);
                }
                _collection.RemoveAt(_collection.Count - 1);
                return top;
            }
            catch (Exception)
            {
                throw new Exception("Stack is empty.");
            }
        }
        public bool IsEmpty
        {
            get
            {
                return _collection.Count == 0;
            }
        }
    }
}
