namespace task1
{
    class Program
    {
        private static int counter = 0;

        static void UpdateCounter1()
        {
            for (int i = 0; i < 10; i++)
            {
                int waitTime = new Random().Next(10);
                Thread.Sleep(waitTime);
                counter++;
            }
           
        }

        static void UpdateCounter2()
        {
            for (int i = 0; i < 10; i++)
            {
                int waitTime = new Random().Next(10);
                Thread.Sleep(waitTime);
                counter++;
            }
            
        }

        public static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                Thread T1 = new Thread(UpdateCounter1);
                Thread T2 = new Thread(UpdateCounter2);

                T1.Start();
                T2.Start();

                T1.Join();
                T2.Join();
                Console.WriteLine(counter);
                /*
                 * Output:
                 * 19 (+19)
                 * 39 (+20)
                 * 59 (+20)
                 * 79 (+20)
                 * 97 (+18)
                 */
            }
        }
    }
}
