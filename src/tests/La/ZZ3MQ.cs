namespace task3
{
    class Program
    {
        public static int MaxNestedEnvelopes(List<Envelope> envelopes)
        {
            int length = envelopes.Count;
            if (length == 0)
            {
                return 0;
            }
            envelopes.Sort((a, b) => a.MinSide.CompareTo(b.MinSide));
           int[] dp = new int[length];
            for (int i = 0; i < length; i++)
            {
                dp[i] = 1;
                for (int j = 0; j < length; j++)
                {
                    if (envelopes[j] < envelopes[i] && dp[i] < dp[j] + 1)
                    {
                        dp[i] = dp[j] + 1;
                    }
                }
            }
            return dp.Max();
        }
        public static void Main(string[] args)
        {
            var envelopes = new List<Envelope>();
            envelopes.Add(new Envelope(5, 4));
            envelopes.Add(new Envelope(6, 4));
            envelopes.Add(new Envelope(6, 7));
            envelopes.Add(new Envelope(2, 3));
            Console.WriteLine(MaxNestedEnvelopes(envelopes)); //3

            envelopes.Clear();
            envelopes.Add(new Envelope(1, 1));
            envelopes.Add(new Envelope(1, 1));
            envelopes.Add(new Envelope(1, 1));
            Console.WriteLine(MaxNestedEnvelopes(envelopes)); //1

        }
    }
}
