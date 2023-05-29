using System;
using System.Linq;

namespace Mailboxes
{
    public class Solver
    {
        private readonly int[] prefixSum;
        private readonly int n, k;

        private int Sum(int i, int j)
        {
            return prefixSum[j] - prefixSum[i - 1];
        }
        
        private int Cost(int i, int j)
        {
            var l = (i + j) / 2;
            var r = (i + j + 1) / 2;
            return Sum(r, j) - Sum(i, l);
        }
        
        public Solver(int[] houses, int _k)
        {
            n = houses.Length;
            k = _k;
            if (k > n) k = n;
            var sortedHouses = houses.ToList();
            sortedHouses.Sort();
            prefixSum = new int[n + 1];
            for (var i = 0; i < n; ++i)
            {
                prefixSum[i + 1] = prefixSum[i] + sortedHouses[i];
            }
        }

        public int Solve()
        {
            var dp = new int[n + 1, k + 1];
            for (var i = 0; i <= n; ++i)
            {
                for (var j = 0; j <= k; ++j)
                {
                    dp[i, j] = (int)1e9;
                }
            }

            dp[0, 0] = 0;
            for (var t = 0; t < k; ++t)
            {
                for (var i = t; i < n; ++i)
                {
                    for (var j = i + 1; j <= n; ++j)
                    {
                        dp[j, t + 1] = Math.Min(dp[j, t + 1], dp[i, t] + Cost(i + 1, j));
                    }
                }
            }
            return dp[n, k];
        }
    }
}