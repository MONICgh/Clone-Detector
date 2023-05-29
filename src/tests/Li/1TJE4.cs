
using System.Collections.Generic;

namespace task3
{
    class StringDifference
    {
        public static int LevensteinDistance(string s1, string s2)
        {
            int firstLength = s1.Length;
            int secondLength = s2.Length;

            var dp = new int[firstLength + 1, secondLength + 1];

            if (firstLength == 0)
            {
                return secondLength;
            }

            if (secondLength == 0)
            {
                return firstLength;
            }

            for (int i = 0; i <= firstLength;  i++) { 
                dp[i, 0] = i; 
            }
            for (int j = 0; j <= secondLength; j++) {
                dp[0, j] = j;
            }

            for (int i = 1; i <= firstLength; i++)
            {
                for (int j = 1; j <= secondLength; j++)
                {
                    int addPrice = (s1[i - 1] == s2[j - 1]) ? 0 : 1;

                    dp[i, j] = Math.Min(
                        Math.Min(dp[i - 1, j] + 1, dp[i, j - 1] + 1),
                        dp[i - 1, j - 1] + addPrice);
                }
            }
            return dp[firstLength, secondLength];
        }
    }
}
