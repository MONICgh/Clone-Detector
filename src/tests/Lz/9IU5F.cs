namespace task4
{
    class Program
    {
        static string ExpressFactors(int n)
        {
            var divisors = new List<string>();

            for (int divisor = 2; divisor < n + 1; divisor++)
            {
                int degree = 0;

                if (n % divisor == 0)
                {
                    while (n % divisor == 0)
                    {
                        n /= divisor;
                        degree++;
                    }

                    string curExp = divisor.ToString();
                    if (degree > 1)
                    {
                        curExp += "^" + degree.ToString();
                    }
                    divisors.Add(curExp);
                }
            }
            return string.Join(" x ", divisors);
        }
        static void Main(string[] args)
        {
            Console.WriteLine(ExpressFactors(2)); // 2
            Console.WriteLine(ExpressFactors(4)); //2^2
            Console.WriteLine(ExpressFactors(10)); //2 x 5
            Console.WriteLine(ExpressFactors(60)); //2^2 x 3 x 5
        }
    }
}
