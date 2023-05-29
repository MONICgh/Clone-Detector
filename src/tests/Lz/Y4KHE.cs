using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeFactorization
{
    public class Factorizer
    {
        public List<Tuple<int, int>> FactorizeToList(int n)
        {
            var primes = new List<Tuple<int, int>>();
            for (var p = 2; p * p <= n; ++p)
            {
                if (n % p != 0) continue;
                var q = 0;
                while (n % p == 0)
                {
                    n /= p;
                    ++q;
                }
                primes.Add(Tuple.Create(p, q));
            }

            if (n != 1)
            {
                primes.Add(Tuple.Create(n, 1));
            }

            return primes;
        }

        public string ExpressFactors(int n)
        {
            var primes = FactorizeToList(n);
            var ans = new StringBuilder();
            var first = true;
            foreach (var pair in primes)
            {
                if (!first)
                {
                    ans.Append(" x ");
                }

                first = false;

                ans.Append(pair.Item1.ToString());
                if (pair.Item2 > 1)
                {
                    ans.Append("^");
                    ans.Append(pair.Item2.ToString());
                }
            }

            return ans.ToString();
        }
    }
}