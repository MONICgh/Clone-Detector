namespace task2
{
    class Program
    {
        private static Semaphore semaphore1 = new Semaphore(1, 1);
        private static Semaphore semaphore2 = new Semaphore(0, 1);

        static void Loop1()
        {
            for (int i=1; i <= 10; ++i)
            {
                semaphore1.WaitOne();
                Console.WriteLine($"T1: {i}");
                semaphore2.Release();
            }
        }

        static void Loop2()
        {
            for (int i = 1; i <= 10; ++i)
            {
                semaphore2.WaitOne();
                Console.WriteLine($"T2: {i}");
                semaphore1.Release();
            }

        }
        public static void Main(string[] args)
        {
            Thread T1 = new Thread(Loop1);  
            Thread T2 = new Thread(Loop2);
            T1.Start();
            T2.Start();

            /*
             * T1: 1
             * T2: 1
             * T1: 2
             * T2: 2
             * T1: 3
             * T2: 3
             * T1: 4
             * T2: 4
             * T1: 5
             * T2: 5
             * T1: 6
             * T2: 6
             * T1: 7
             * T2: 7
             * T1: 8
             * T2: 8
             * T1: 9
             * T2: 9
             * T1: 10
             * T2: 10
             */
        }
    }
    
}
