namespace Task2;

public class ImmutablePair<T, R>
{
    public T Left { get; }
    public R Right { get; }

    public ImmutablePair(T left, R right)
    {
        Left = left;
        Right = right;
    }

    public ImmutablePair<T, R> UpdateLeft(T left)
    {
        return new ImmutablePair<T, R>(left, Right);
    }

    public ImmutablePair<T, R> UpdateRight(R right)
    {
        return new ImmutablePair<T, R>(Left, right);
    }
}