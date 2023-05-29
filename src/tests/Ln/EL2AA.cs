using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HW02.ImmutableList
{
    public class ImmutableList<T> : IReadOnlyList<T>
    {
        private readonly List<T> _data;
        public ImmutableList(List<T> data)
        {
            _data = data;
        }

        public ImmutableList<T> Insert(int index, T item)
        {
            var newData = new List<T>(_data);
            newData.Insert(index, item);
            return new ImmutableList<T>(newData);
        }

        public ImmutableList<T> Add(T item)
        {
            var newData = new List<T>(_data) { item };
            return new ImmutableList<T>(newData);
        }

        public ImmutableList() : this(new List<T>())
        {
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _data.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Count { get { return _data.Count; } }

        public T this[int index]
        {
            get
            {
                return _data[index];
            }
        }
    }
}
