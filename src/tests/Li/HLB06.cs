using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;

namespace Application
{
    class Task3
    {
        static bool DistNotMore1String(string s1, string s2)
        {
            var fixWas = false;
            int i = 0;
            int j = 0;
            if (Math.Abs(s1.Length - s2.Length) > 1)
            {
                return false;
            }
            else if (s1.Length == s2.Length)
            {
                for (; i < s1.Length; i++)
                {
                    if (s1[i] != s2[i])
                    {
                        if (fixWas)
                        {
                            return false;
                        }
                        else
                        {
                            fixWas = true;
                        }
                    }
                }
                return true;
            }
            while (i < s1.Length && j < s2.Length)
            {
                if (s1[i] != s2[j])
                {
                    if (fixWas)
                    {
                        return false;
                    }
                    fixWas = true;
                    if (s1.Length < s2.Length)
                    {
                        j++;
                    }
                    else
                    {
                        i++;
                    }
                }
                else
                {
                    i++;
                    j++;
                }
            }
            return true;
        }

        static void Main()
        {
            var strings = new List<Tuple<String, String>>() {
                new Tuple<String, String>("word", "word"),
                new Tuple<String, String>("wored", "word"),
                new Tuple<String, String>("word", "wored"),
                new Tuple<String, String>("work", "word"),
                new Tuple<String, String>("wword", "word"),

                new Tuple<String, String>("wordss", "word"),
                new Tuple<String, String>("words", "wor"),
                new Tuple<String, String>("wword", "words")
            };
            foreach (Tuple<String, String> s1_s2 in strings)
            {
                Console.WriteLine("{0}, {1}: {2}", s1_s2.Item1, s1_s2.Item2, DistNotMore1String(s1_s2.Item1, s1_s2.Item2));
            }
        }
    }
}
