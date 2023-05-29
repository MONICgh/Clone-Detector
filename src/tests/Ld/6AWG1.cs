using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Palindrome
{
    struct Pair
    {
        long seed;
        Int32 steps;
        public Pair(long seed, Int32 steps)
        {
            this.seed = seed;
            this.steps = steps;
        }

        public override string ToString()
        {
            return $"({seed}, {steps})";
        }
    }
    class Palindrome
    {
        public Pair PalSeq(long palindrome)
        {
            long seed = 1;
            Int32 steps = Check(palindrome, seed);
            while (steps == -1)                         //перебираем числа по одному, что-то рано или поздно будет ответом
            {
                seed++;
                steps = Check(palindrome, seed);
            }
            return new Pair(seed, steps);
        }

        private Int32 Check(long palindrome, long seed) //проделываем процедуру для числа и проверяем, подходит ли оно
        {
            Int32 steps = 0;
            while (seed < palindrome)
            {
                seed += ReverseInt(seed);
                steps++;
            }
            if (seed == palindrome)
            {
                return steps;
            }
            return -1;
        }

        private long ReverseInt(long a) //питоновское int(str(a)[::-1]) как-то не проходит, поэтому целая процедура для переворота числа.
        {
            string s = a.ToString();
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            s = new string(arr);
            return long.Parse(s);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var myArray = new long[] { 4884, 1, 11, 3113, 8836886388 };
            var pal = new Palindrome();
            foreach (long a in myArray)
            {
                Console.WriteLine("PalSeq(" + $"{a}" + ") -> " + $"{pal.PalSeq(a)}");
            }
        }
    }
}