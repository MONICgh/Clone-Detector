namespace LuckyTicket
{
    public class LuckyTicket
    {
        public static long NumLuckyTicket(int len)
        {
            if (len % 2 == 1)
            {
                return 0;
            }
            len /= 2;
            long[,] dp = new long[len + 1, 9 * len + 1];

            dp[0, 0] = 1;
            for (int pref = 1; pref <= len; pref++)
                for (int sum = 0; sum <= 9 * pref; sum++)
                    for (int last = 0; last <= Math.Min(9, sum); last++)
                        dp[pref, sum] += dp[pref - 1, sum - last];
            
            long luckyTicket = 0;
            for (int sum = 0; sum <= 9 * len; sum++)
            {
                luckyTicket += dp[len, sum] * dp[len, sum];
            }
            return luckyTicket;
        }
    }
}