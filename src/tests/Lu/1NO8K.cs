using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab9
{
    static class RepeatingDecimal
    {
        public static string Rational(ulong numerator, ulong denominator)
        {
            var digits = new List<char> { '0', '.' };
            Console.WriteLine("{0} % {1} = {2}", numerator, denominator, numerator % denominator);
            numerator %= denominator;
            var results = new Dictionary<ulong, int>();
            while (numerator > 0)
            {
                if (results.ContainsKey(numerator))
                {
                    digits.Insert(results[numerator], '(');
                    digits.Add(')');
                    break;
                }
                else
                {
                    results[numerator] = digits.Count;
                    numerator *= 10;
                    digits.Add((numerator / denominator).ToString()[0]);
                    numerator %= denominator;
                }
            }
            return new string(digits.ToArray());
        }
    }
}
