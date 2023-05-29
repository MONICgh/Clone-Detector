using System.Collections.Generic;
using System.Linq;

namespace FibonacciString
{
    public class Solver
    {
        private List<string> fib = new List<string>();

        public Solver()
        {
            fib.Add("b");
            fib.Add("a");
        }

        public string StringyFib(int n)
        {
            if (n < 2)
            {
                return "invalid";
            }

            while (fib.Count < n)
            {
                fib.Add(fib[fib.Count - 1] + fib[fib.Count - 2]);
            }

            return string.Join(", ", fib.Take(n));
        }
    }
}