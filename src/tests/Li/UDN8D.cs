using System.Collections.Generic;

namespace StringSort
{
    public class Comparator : IComparer<char>
    {
        private int Type(char a)
        {
            if (char.IsLower(a)) return 0;
            if (char.IsUpper(a)) return 1;
            if (char.IsDigit(a)) return 2;
            return 3;
        }
        
        public int Compare(char a, char b)
        {
            var aType = Type(a);
            var bType = Type(b);
            if (aType == 2 && bType == 2)
            {
                return a.CompareTo(b);
            }

            if (aType == 2 || bType == 2)
            {
                return aType.CompareTo(bType);
            }

            if (char.ToLower(a) != char.ToLower(b))
            {
                return char.ToLower(a).CompareTo(char.ToLower(b));
            }

            return aType.CompareTo(bType);
        }
    }
}