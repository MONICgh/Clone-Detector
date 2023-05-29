namespace SparseMatrix;

public record SparseItem<T>(int X, int Y, int Z, T value);

public class SparseItemComparator<T> : IComparer<SparseItem<T>>
{
    public int Compare(SparseItem<T>? x, SparseItem<T>? y)
    {
        if (ReferenceEquals(x, y)) return 0;
        if (ReferenceEquals(null, y)) return 1;
        if (ReferenceEquals(null, x)) return -1;
        var xComparison = x.X.CompareTo(y.X);
        if (xComparison != 0) return xComparison;
        var yComparison = x.Y.CompareTo(y.Y);
        if (yComparison != 0) return yComparison;
        return x.Z.CompareTo(y.Z);
    }
}