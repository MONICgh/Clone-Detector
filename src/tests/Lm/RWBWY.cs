namespace CollectionSort;

public class NameComparator : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        if (ReferenceEquals(x, y)) return 0;
        if (ReferenceEquals(null, y)) return 1;
        if (ReferenceEquals(null, x)) return -1;
        if (x.Name.Length != y.Name.Length) return x.Name.Length - y.Name.Length;
        if (x.Name.Length == 0) return 0;
        return char.ToLower(x.Name.First()) - char.ToLower(y.Name.First());
    }
}

public class AgeComparator : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        if (ReferenceEquals(x, y)) return 0;
        if (ReferenceEquals(null, y)) return 1;
        if (ReferenceEquals(null, x)) return -1;
        return x.Age.CompareTo(y.Age);
    }
}