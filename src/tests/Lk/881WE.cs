using System;

namespace LuckyTickets
{
    public class LuckyTicketsCounter
    {
        public LuckyTicketsCounter()
        {
        }

        public ulong Count(int n)
        {
            if (n % 2 == 1)
            {
                throw new ArgumentException("Length of a ticket must be even!");
            }

            n /= 2;
            var dp = new ulong[9 * n + 1];
            dp[0] = 1;
            for (var i = 0; i < n; ++i)
            {
                var ndp = new ulong[9 * n + 1];
                for (var dig = 0; dig <= 9; ++dig)
                {
                    for (var j = 0; j <= 9 * n - dig; ++j)
                    {
                        ndp[j + dig] += dp[j];
                    }
                }

                for (var j = 0; j <= 9 * n; ++j)
                {
                    dp[j] = ndp[j];
                }
            }
            ulong ans = 0;
            for (var sum = 0; sum <= 9 * n; ++sum)
            {
                ans += dp[sum] * dp[sum];
            }

            return ans;
        }
    }
}