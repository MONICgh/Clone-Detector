namespace Over9999
{
    class Program
    {
        static int[] GetRandomSuffle()
        {
            int n = 100000000;
            var arr = new int[n];
            var rand = new Random();
            for (int i = 0; i < n; i++)
                arr[i] = i;
            for (int i = n - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);
                var temp = arr[j];
                arr[j] = arr[i];
                arr[i] = temp;
            }
            return arr;
        }

        static void PrintInFile()
        {
            using (var writer = new StreamWriter("bigfile.txt"))
            {
                var arr = GetRandomSuffle();
                foreach (var line in arr)
                {
                    writer.WriteLine(line.ToString("D8"));
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine($"File is at '{Environment.CurrentDirectory}'");
            PrintInFile();
        }
    }
}
