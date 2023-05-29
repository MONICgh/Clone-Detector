namespace Task2;

public class ComparerName : IComparer<Person>
{
    public int Compare(Person? x, Person? y)
    {
        if (x == null && y == null)
            return 0;
        if (x == null)
            return -1;
        if (y == null)
            return 1;
        
        if (x.Name.Length > y.Name.Length)
            return 1;
        if (x.Name.Length < y.Name.Length)
            return -1;
        
        if (x.Name.ToLower()[0] < y.Name.ToLower()[0])
            return -1;
        if (x.Name.ToLower()[0] > y.Name.ToLower()[0])
            return 1;

        return 0;
    }
}