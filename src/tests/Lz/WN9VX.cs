namespace task3
{
    class Program
    {
        public static int SunLoungers(string s)
        {
            var places = s.ToCharArray();
            int n = places.Length;
            int maxCount = 0;

            if (n == 1) return places[0] == '0' ? 1 : 0;

            for (int i = 0; i < n; ++i)
            {
                if (i == 0 && places[i + 1] == '1')
                {
                    continue;
                }

                if (i == n - 1 && places[i-1] == '1')
                {
                    continue;
                }

                if (places[i] == '0' && (i == 0 || i == n-1 || places[i - 1] == '0' && places[i + 1] == '0'))
                {
                    places[i] = '1';
                    maxCount++;
                }
            }

            return maxCount;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(SunLoungers("10001")); // 1
            Console.WriteLine(SunLoungers("00101")); // 1
            Console.WriteLine(SunLoungers("0")); // 1
            Console.WriteLine(SunLoungers("000")); //2
            Console.WriteLine(SunLoungers("1101")); //0
        }
    }
}
