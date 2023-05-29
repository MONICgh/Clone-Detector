using System;
using System.Collections.Generic;
using System.Linq;

namespace PalindromSolver
{
    public static class PalindromeSolver
    {
        private static int ReversedNumber(int number)
        {
            var s = new string(number.ToString().Reverse().ToArray());
            return int.Parse(s);
        }

        public static Tuple<int, int> Solve(long palindrome)
        {
            for (var i = 1; i <= 10000; i++)
            {
                var current = i;
                int steps = 0;
                while (current < palindrome)
                {
                    current += ReversedNumber(current);
                    steps++;
                }
                if (current == palindrome)
                {
                    return new Tuple<int, int>(i, steps);
                }
            }
            return null;
        }
    }
}
