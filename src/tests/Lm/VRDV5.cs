namespace SortCollection
{
    internal class ComparatorName : IComparer<Person>
    {
        public int Compare(Person? x, Person? y)
        {
            if (x == null && y == null)
            {
                return 0;
            }
            if (x == null)
            {
                return -1;
            }
            if (y == null)
            {
                return 1;
            }

            if (x.Name.Length != y.Name.Length)
            {
                return x.Name.Length - y.Name.Length;
            }

            if (x.Name.Length > 0)
            {
                return Char.ToLower(x.Name[0]) - Char.ToLower(y.Name[0]);
            }
            return 0;
        }
    }
}
