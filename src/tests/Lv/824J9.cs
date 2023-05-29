using System.Collections.Generic;
using System.Linq;

namespace ThreeSum
{
    public class Solver
    {
        public (int, int, int)[] ThreeSum(int[] array)
        {
            var set = new HashSet<(int, int, int)>();
            var len = array.Length;
            for (var i = 0; i < len; ++i)
            {
                for (var j = i + 1; j < len; ++j)
                {
                    for (var k = j + 1; k < len; ++k)
                    {
                        if (array[i] + array[j] + array[k] == 0)
                        {
                            set.Add((array[i], array[j], array[k]));
                        }
                    }
                }
            } 
            return set.OrderBy(item => item.Item1).ToArray();
        }

    }
}