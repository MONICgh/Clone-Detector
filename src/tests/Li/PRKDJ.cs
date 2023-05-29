using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;

namespace Application
{
    class Task6s
    {
        static string stringyFib(int n)
        {
            if (n < 2)
            {
                return "invalid";
            }
            StringBuilder answer = new StringBuilder();
            var fibs = new Tuple<StringBuilder, StringBuilder>(new StringBuilder("b"), new StringBuilder("a"));
            answer.Append($"{fibs.Item1} {fibs.Item2} ");
            for (int i = 2; i < n; i++)
            {
                if (i % 2 == 0)
                {
                    fibs.Item1.Insert(0, fibs.Item2);
                    answer.Append($"{fibs.Item1} ");
                }
                else
                {
                    fibs.Item2.Insert(0, fibs.Item1);
                    answer.Append($"{fibs.Item2} ");
                }
            }
            return answer.ToString();
        }

        static void Main()
        {
            var ints = new List<int>() { 1, 3, 7 };
            foreach (int i in ints)
            {
                Console.WriteLine("stringyFib({0}) -> {1}", i, stringyFib(i));
            }
        }
    }
}
