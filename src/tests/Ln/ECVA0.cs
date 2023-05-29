namespace Application
{
    class Task1
    {
        static int diceRoll(int n, int sum)
        {
            if (n < 0 || n > 6) throw new ArgumentException("n should be in [1, 6]");
            sum = sum - n + 1;
            if (sum <= 0) return 0;
            var dp = new int[n, sum];
            for (int i = 0; i < Math.Min(sum, 6); i++) {
                dp[0, i] = 1;
            }
            for (int i = 1; i < Math.Min(n, 6); i++)
            {
                dp[i, 0] = 1;
            }

            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < sum; j++)
                {
                    for (int k = 0; k < 6; k++)
                    {
                        if (j - k < 0) break;
                        dp[i, j] += dp[i - 1, j - k];
                    }
                }
            }
            return dp[n-1, sum-1];
        }

        static int Main()
        {
            Console.WriteLine("diceRoll({0}, {1}) => {2}", 2, 6, diceRoll(2, 6));
            Console.WriteLine("diceRoll({0}, {1}) => {2}", 2, 2, diceRoll(2, 2));
            Console.WriteLine("diceRoll({0}, {1}) => {2}", 1, 3, diceRoll(1, 3));
            Console.WriteLine("diceRoll({0}, {1}) => {2}", 2, 5, diceRoll(2, 5));
            Console.WriteLine("diceRoll({0}, {1}) => {2}", 3, 4, diceRoll(3, 4));
            Console.WriteLine("diceRoll({0}, {1}) => {2}", 4, 18, diceRoll(4, 18));
            Console.WriteLine("diceRoll({0}, {1}) => {2}", 6, 20, diceRoll(6, 20));

            Console.WriteLine("diceRoll({0}, {1}) => {2}", 6, 37, diceRoll(6, 37));
            Console.WriteLine("diceRoll({0}, {1}) => {2}", 6, 5, diceRoll(6, 5));
            try
            {
                Console.WriteLine("diceRoll({0}, {1}) => {2}", 7, 20, diceRoll(7, 20));
            }
            catch (Exception ex)
            {
                Console.WriteLine("diceRoll({0}, {1}) failed: {2}", 7, 20, ex.Message);
            }
            return 0;
        }
    }
}
