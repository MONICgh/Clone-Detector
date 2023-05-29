using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Divisors
{
    class Divisors
    {
        public string ExpressFactors(int n)
        {
            string ans = "";
            var d = 2;
            var divisors = new Dictionary<int, int>();  //map

            if (n <= 0)
                throw new Exception("negative number");
            if (n == 1)
                return "1";

            while (n > 1 && d <= n)
            {
                if (n % d == 0)
                {
                    n /= d;
                    if (!divisors.ContainsKey(d))
                        divisors.Add(d, 0);
                    divisors[d]++;
                }
                else
                {
                    d++;
                }
            }

            foreach (var div in divisors.Keys)
            {
                ans += $"{div}";
                if (divisors[div] > 1)
                    ans += $"^{divisors[div]}";
                ans += " x ";
            }
            return ans.Substring(0, ans.Length - 3);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var d = new Divisors();
            int[] a = { 2, 4, 10, 60, 100, 239, 143095 };
            foreach (int t in a)
            {
                Console.WriteLine("ExpressFactors(" + t + ") -> " + d.ExpressFactors(t));
            }

        }
    }
}