using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;

namespace RepeatingSubstring
{
    public class Solver
    {
        private readonly List<long> powers = new List<long> { 1 };
        private readonly long P = 997;
        private readonly int mod = (int)1e9 + 7;

        public string Solve(string s)
        {
            var n = s.Length;
            while (powers.Count <= n)
            {
                powers.Add(powers.Last() * P % mod);
            }

            var prefixHash = new long[n + 1];
            for (var i = 1; i <= n; ++i)
            {
                prefixHash[i] = (prefixHash[i - 1] + powers[i - 1] * s[i - 1]) % mod;
            }

            var l = 0;
            var r = n;
            var lastIndexFound = -1;
            while (l + 1 < r)
            {
                var m = (l + r) / 2;
                var indexFound = -1;
                var counter = new Dictionary<long, int>();

                for (var i = m - 1; i < n; ++i)
                {
                    var hash = prefixHash[i + 1] - prefixHash[i - m + 1];
                    if (hash < 0)
                    {
                        hash += mod;
                    }

                    hash *= powers[n - 1 - i];
                    hash %= mod;
                    
                    if (!counter.ContainsKey(hash))
                    {
                        counter.Add(hash, 0);
                    }
                    ++counter[hash];
                    if (counter[hash] == 2)
                    {
                        indexFound = i - m + 1;
                        break;
                    }
                }
                
                if (indexFound != -1)
                {
                    l = m;
                    lastIndexFound = indexFound;
                }
                else
                {
                    r = m;
                }
            }

            return l == 0 ? "" : s.Substring(lastIndexFound, l);
        }
    }
}