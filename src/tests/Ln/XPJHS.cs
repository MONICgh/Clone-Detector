namespace ImmutablePair
{
    public class ImmutablePair<T1, T2>
    {
        private readonly T1 _first;
        private readonly T2 _second;

        public ImmutablePair(T1 x, T2 y)
        {
            _first = x;
            _second = y;
        }

        public ImmutablePair<T1, T2> ChangeFirst(T1 nfirst)
        {
            return new ImmutablePair<T1, T2>(nfirst, _second);
        }

        public ImmutablePair<T1, T2> ChangeSecond(T2 nsecond)
        {
            return new ImmutablePair<T1, T2>(_first, nsecond);
        }

        public T1 GetFirst()
        {
            return _first;
        }

        public T2 GetSecond()
        {
            return _second;
        }

        public override string ToString()
        {
            return $"{_first}, {_second}";
        }
    }
}