using System.Collections;

namespace HW_06.Sparse2D;

public class Sparse1DTable<T> : IEnumerable<T>
{
    private readonly Dictionary<int, T?> _datatable = new();

    private struct SparseEnumerator<TS> : IEnumerator<TS>
    {
        private Dictionary<int, TS?>.Enumerator _enumerator;

        public SparseEnumerator(Dictionary<int, TS?>.Enumerator list)
        {
            _enumerator = list;
        }

        public void Dispose()
        {
            _enumerator.Dispose();
        }

        public bool MoveNext()
        {
            return _enumerator.MoveNext();
        }

        public TS? Current
        {
            get
            {
                return _enumerator.Current.Value;
            }
        }

        object? IEnumerator.Current { get { return Current; } }

        void IEnumerator.Reset()
        {
            ((IEnumerator)_enumerator).Reset();
        }
    }

    public T? this[int i]
    {
        get { return _datatable.GetValueOrDefault(i, default(T)); }
        set
        {
            _datatable[i] = value;
        }
    }


    public IEnumerator<T> GetEnumerator()
    {
        return new SparseEnumerator<T>(_datatable.GetEnumerator());
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

}

public class Sparse2DTable<T> : IEnumerable<T>
{
    private Sparse1DTable<Sparse1DTable<T>> data = new();

    public Sparse1DTable<T> this[int i]
    {
        get
        {
            var value = data[i];
            if (value == null)
                data[i] = new Sparse1DTable<T>();
            return data[i]!;
        }
    }

    private struct SparseEnumerator<TS> : IEnumerator<TS>
    {
        private readonly IEnumerator<Sparse1DTable<TS>> _enumerator;

        public SparseEnumerator(IEnumerator<Sparse1DTable<TS>> list)
        {
            _enumerator = list;

            _enumerator.MoveNext();
            Current1D = _enumerator.Current.GetEnumerator();
        }
        private IEnumerator<TS> Current1D { get; set; }

        public void Dispose()
        {
            _enumerator.Dispose();
        }

        public bool MoveNext()
        {
            if (Current1D.MoveNext())
                return true;
            if (!_enumerator.MoveNext())
            {
                return false;
            }
            Current1D = _enumerator.Current.GetEnumerator();
            Current1D.MoveNext();
            return true;
        }

        public TS? Current
        {
            get
            {
                return Current1D.Current;
            }
        }

        object? IEnumerator.Current { get { return Current; } }

        void IEnumerator.Reset()
        {
            _enumerator.Reset();
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new SparseEnumerator<T>(data.GetEnumerator());
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
