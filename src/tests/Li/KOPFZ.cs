using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;

namespace Application
{
    class CharComparer : IComparer<char>
    {
        public int Compare(char x, char y)
        {
            if (x == y)
            {
                return 0;
            }
            if (x <= '9' && x >= '0')
            {
                if (y <= '9' && y >= '0')
                {
                    return y - x;
                }
                return -1;
            }
            if (y <= '9' && y >= '0')
            {
                return 1;
            }
            var x_lower = Char.ToLower(x);
            var y_lower = Char.ToLower(y);
            if (x_lower == y_lower)
            {
                if (x_lower == x)
                {
                    return 1;
                }
                return -1;
            }
            return y_lower - x_lower;
        }
    }

    class Task5
    {
        static string sorting(string s)
        {
            return String.Concat(s.OrderByDescending(c => c, new CharComparer()));
        }

        static void Main()
        {
            var strings = new List<String>() {
                "eA2a1E",
                "Re4r",
                "6jnM31Q",
                "846ZIbo"
            };
            foreach (String s in strings)
            {
                Console.WriteLine("sorting({0}) -> {1}", s, sorting(s));
            }
        }
    }
}
