using System.Collections.Generic;

namespace StringSort
{
    public class Solver
    {
        public string Sorting(string s)
        {
            var list = new List<char>();
            list.AddRange(s);
            list.Sort(new Comparator());
            return string.Concat(list);
        }
    }
}