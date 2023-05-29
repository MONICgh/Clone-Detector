using System.Reflection;

namespace Application
{
    class Task1
    {
        private static int x;
        private static Random rnd = new Random();
        
        static void UpdateX(Func<int, int> fun)
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(rnd.Next(1, 100));
                x = fun(x);
            }
        }
        
        static void Main()
        {
            Thread fun1Thread = new Thread(() => UpdateX(x => x + 1));
            Thread fun2Thread = new Thread(() => UpdateX(x => x * 2));
            fun1Thread.Start();
            fun2Thread.Start();
            fun1Thread.Join();
            fun2Thread.Join();
            Console.WriteLine($"x={x}");
        }
    }
}
