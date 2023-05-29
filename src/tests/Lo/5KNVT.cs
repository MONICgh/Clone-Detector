namespace Program
{
    public class Program
    {
        public static void Func1A(ref bool flag)
        {
            if (flag)
            {
                Console.WriteLine("Thread A reaches secret point!");
            }
            Thread.Sleep(1000);
            flag = false;
            Console.WriteLine("Thread A finishes!");
        }

        public static void Func1B(ref bool flag)
        {
            if (flag)
            {
                Console.WriteLine("Thread B reaches secret point!");
            }
            Thread.Sleep(1000);
            flag = false;
            Console.WriteLine("Thread B finishes!");
        }

        public static void Func2A(ref bool flag)
        {
            if (flag)
            {
                Console.WriteLine("Thread A reaches secret point!");
            }
            flag = false;
            Console.WriteLine("Thread A finishes!");
        }

        public static void Func2B(ref bool flag)
        {
            Thread.Sleep(1000);
            if (flag)
            {
                Console.WriteLine("Thread B reaches secret point!");
            }
            flag = false;
            Console.WriteLine("Thread B finishes!");
        }

        public static void Main()
        {
            bool flag = true;
            Thread A = new(() => Func1A(ref flag));
            Thread B = new(() => Func1B(ref flag));
            A.Start();
            B.Start();
            A.Join();
            B.Join();

            Console.WriteLine("--------------");

            flag = true;
            Thread C = new(() => Func2A(ref flag));
            Thread D = new(() => Func2B(ref flag));
            C.Start();
            D.Start();
            C.Join();
            D.Join();
        }
    }
}