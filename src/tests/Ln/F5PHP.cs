namespace DiceRollSolveTool
{
    public class DiceRollSolver
    {
        public int Solve(int n, int sum)
        {
            if (sum < n || sum > 6 * n)
            {
                return 0;
            }
            var dp = new int[n + 1, 6 * n + 1];
            dp[0, 0] = 1;
            for (var i = 0; i < n; ++i)
            {
                for (var j = i; j <= 6 * i; ++j)
                {
                    for (var k = 1; k <= 6; ++k)
                    {
                        dp[i + 1, j + k] += dp[i, j];
                    }
                }
            }
            return dp[n, sum];
        }

        public int NaiveSolve(int n, int sum)
        {
            if (n == 0)
            {
                return sum == 0 ? 1 : 0;
            }

            var res = 0;
            for (var i = 1; i <= 6; ++i)
            {
                res += NaiveSolve(n - 1, sum - i);
            }

            return res;
        }
    }
}