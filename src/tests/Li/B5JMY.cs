namespace MergeStrings
{
    public class MergeStrings
    {
        public static string mergeStrings(string s, string t)
        {
            string[] wordS = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] wordT = t.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int[,] dp = new int[wordS.Length + 1, wordT.Length + 1];
            for (int i = 1; i <= wordS.Length; i++)
            {
                for (int j = 1; j <= wordT.Length; j++)
                {
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    if (wordS[i - 1] == wordT[j - 1])
                    {
                        dp[i, j] = Math.Max(dp[i, j], dp[i - 1, j - 1] + 1);
                    }
                }
            }

            int curS = wordS.Length;
            int curT = wordT.Length;
            List<string> answer = new();
            while (curS > 0 || curT > 0)
            {
                while (curT > 0 && dp[curS, curT] == dp[curS, curT - 1])
                {
                    answer.Add(wordT[curT - 1]);
                    curT--;
                }
                while (curS > 0 && dp[curS, curT] == dp[curS - 1, curT])
                {
                    answer.Add(wordS[curS - 1]);
                    curS--;
                }
                if (curS > 0)
                {
                    answer.Add(wordS[curS - 1]);
                    curS--;
                    curT--;
                }
            }
            answer.Reverse();

            return string.Join(' ', answer);
        }
    }
}