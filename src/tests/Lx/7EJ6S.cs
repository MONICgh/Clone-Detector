namespace minstack
{
    public class MinStack<T> where T : IComparable
    {
        private T[] _data;
        private T[] _mins;
        private int _capacity;
        private int _dataSize;
        private int _minsSize;

        public int Count => _dataSize;

        public MinStack() : this(capacity: 1)
        {
        }

        public MinStack(int capacity)
        {
            _data = new T[capacity];
            _mins = new T[capacity];
            _capacity = capacity;
            _dataSize = 0;
            _minsSize = 0;
        }

        private void _resizeCapacity(int capacity)
        {
            while (_capacity < capacity)
            {
                _capacity *= 2;
            }
            var newData = new T[_capacity];
            var newMins = new T[_capacity];
            _data.CopyTo(newData, 0);
            _mins.CopyTo(newMins, 0);
            _data = newData;
            _mins = newMins;
        }

        public bool IsEmpty => _dataSize == 0;

        public T Top
        {
            get
            {
                try
                {
                    return _data[_dataSize - 1];
                }
                catch (Exception)
                {
                    throw new Exception("Stack is empty");
                }
            }
        }

        public T MinValue()
        {
            try
            {
                return _mins[_minsSize - 1];
            }
            catch (Exception)
            {
                throw new Exception("Stack is empty");
            }
        }

        public void Push(T item)
        {
            if (_dataSize + 1 >= _capacity)
            {
                _resizeCapacity(_dataSize + 1);
            }

            _data[_dataSize++] = item;
            if (_minsSize == 0 || item.CompareTo(MinValue()) <= 0)
            {
                _mins[_minsSize++] = item;
            }
        }

        public T Pop()
        {
            try
            {
                var item = _data[--_dataSize];
                if (item.Equals(_mins[_minsSize - 1]))
                {
                    _minsSize--;
                }
                return item;
            }
            catch (Exception)
            {
                throw new Exception("Stack is empty");
            }
        }

        public T[] ToArray()
        {
            T[] newArray = new T[_dataSize];

            if (_dataSize > 0)
            {
                Array.Copy(_data, 0, newArray, 0, _dataSize);
            }

            return newArray;
        }
    }
}