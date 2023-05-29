namespace task1
{
    class Program
    {
        static object resource1 = new object();
        static object resource2 = new object();

        static void ThreadAction1()
        {
            lock(resource1)
            {
                Console.WriteLine("Thread1 locked resource1");
                Thread.Sleep(1000);
                lock(resource2)
                {
                    Console.WriteLine("No deadlocks occured!");
                }

            }
        }

        static void ThreadAction2()
        {
            lock (resource2)
            {
                Console.WriteLine("Thread2 locked resource2");
                Thread.Sleep(1000);
                lock (resource1)
                {
                    Console.WriteLine("No deadlocks occured!");
                }

            }
        }
        public static void Main(string[] args)
        {
            Thread thread1 = new Thread(ThreadAction1);
            Thread thread2 = new Thread(ThreadAction2);

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine("Finished!");

            /* Output: 
             * Thread1 locked resource1
             * Thread2 locked resource2
            */
        }
    }
}