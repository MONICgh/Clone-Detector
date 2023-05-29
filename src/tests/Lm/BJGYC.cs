using System.Collections;

namespace HW_06.Lake;

public class Lake : IEnumerable<int>
{
    private List<int> _data;

    public Lake(List<int> data)
    {
        _data = data;
    }

    private struct EnumeratorLake : IEnumerator<int>
    {
        private readonly List<int> _list;
        private int _index;
        private bool _movesBack = false;

        public EnumeratorLake(List<int> list)
        {
            _list = list;
            _index = 0;
            Current = default(int);
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (_list.Count == 0)
            {
                return false;
            }
            if (_index < 0)
            {
                return false;
            }
            Current = _list[_index];
            if (_movesBack)
            {
                _index -= 2;
            }
            else
            {
                if (_index + 2 >= _list.Count)
                {
                    if (_index + 1 >= _list.Count)
                    {
                        _index -= 1;
                    }
                    else
                    {
                        _index += 1;
                    }
                    _movesBack = true;
                }
                else
                {
                    _index += 2;
                }
            }
            return true;
        }

        public int Current { get; private set; }

        object IEnumerator.Current { get { return Current; } }

        void IEnumerator.Reset()
        {
            _index = 0;
            Current = default(int);
        }
    }

    public IEnumerator<int> GetEnumerator()
    {
        return new EnumeratorLake(_data);
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
