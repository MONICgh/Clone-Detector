namespace ImmutableType;

public class ImmutablePair<T>
{
    public T first { get; }
    public T second { get; }

    public ImmutablePair(T firstValue, T secondValue)
    {
        first = firstValue;
        second = secondValue;
    }

    public ImmutablePair<T> setFirst(T value)
    {
        return new ImmutablePair<T>(value, second);
    }

    public ImmutablePair<T> setSecond(T value)
    {
        return new ImmutablePair<T>(first, value);
    }
}