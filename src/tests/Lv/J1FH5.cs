using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    public class Element
    {
        public string name;

        public Element(string x)
        {
            name = x;
        }
    }

    public class Solver
    {
        public string Solve(IEnumerable<Element> list, char delimiter)
        {
            return list.Select(item => item.name).Skip(3).Aggregate((x, y) => x + delimiter + y);
        }
    }
}