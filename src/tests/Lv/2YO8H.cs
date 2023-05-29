using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    public class Solver
    {
        public IEnumerable<string> Solve(IEnumerable<string> list)
        {
            return list.Where((item, index) => item.Length > index);
        }
    }
}