using System.Reflection.Metadata.Ecma335;

namespace SortString
{
    public class InterestingComparer : IComparer<char>
    {
        public int Compare(char x, char y)
        {
            if (x == y)
            {
                return 0;
            }

            if (char.IsLetter(x) != char.IsLetter(y))
            {
                return char.IsLetter(x) ? -1 : 1;
            }
            if (char.IsLetter(x))
            {
                if (char.ToLower(x) != char.ToLower(y))
                {
                    return char.ToLower(x).CompareTo(char.ToLower(y));
                }
                else
                {
                    return char.IsLower(x) ? -1 : 1;
                }
            }
            return x.CompareTo(y);
        }
    }

    public class Sorting
    {
        public static string sortString(string s)
        {
            char[] symbols = s.ToCharArray();
            Array.Sort(symbols, new InterestingComparer());
            return string.Concat(symbols);
        }
    }
}