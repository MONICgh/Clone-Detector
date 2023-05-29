namespace SleepSort
{
    public class Program
    {
        public static void Main()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] str = new string[n];
            for (int i = 0; i < n; i++)
            {
                str[i] = Console.ReadLine();
            }

            Thread[] threads = new Thread[n];
            for (int i = 0; i < n; i++)
            {
                string s = str[i];   
                threads[i] = new Thread(() =>
                {
                    Thread.Sleep(50 * s.Length);
                    Console.WriteLine(s);
                });
            }

            for (int i = 0; i < n; i++)
            {
                threads[i].Start();
            }
            for (int i = 0; i < n; i++)
            {
                threads[i].Join();
            }

            Console.WriteLine("-----------");

            List<string> sortedStr = new();
            for (int i = 0; i < n; i++)
            {
                string s = str[i];
                threads[i] = new Thread(() =>
                {
                    Thread.Sleep(50 * s.Length);
                    lock(sortedStr)
                    {
                        sortedStr.Add(s);
                    }
                });
            }
            for (int i = 0; i < n; i++)
            {
                threads[i].Start();
            }
            for (int i = 0; i < n; i++)
            {
                threads[i].Join();
            }

            foreach (string s in sortedStr)
            {
                Console.WriteLine(s);
            }
        }
    }
}