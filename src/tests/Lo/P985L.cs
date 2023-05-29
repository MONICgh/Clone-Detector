using System.Diagnostics.Metrics;
using System.Reflection;

namespace Application
{
    class Task2
    {
        private static int CurrentFuncI = 1;
        
        static void Fun(Action action, int order)
        {
            var spin = new SpinWait();
            while (true)
            {
                if (order == CurrentFuncI)
                {
                    action();
                    Console.Out.Flush();
                    Interlocked.Increment(ref CurrentFuncI);
                    break;
                }
                spin.SpinOnce();
            }
        }
        
        static void FooShow(Foo foo)
        {
            Thread fun1Thread = new Thread(() => Fun(() => 
            {
                foo.first();
            }, 1));
            Thread fun2Thread = new Thread(() => Fun(() => 
            {
                foo.second();
            }, 2));
            Thread fun3Thread = new Thread(() => Fun(() => 
            {
                foo.third();
            }, 3));
            fun3Thread.Start();
            Thread.Sleep(100);
            fun2Thread.Start();
            Thread.Sleep(100);
            fun1Thread.Start();
            fun1Thread.Join();
            fun2Thread.Join();
            fun3Thread.Join();
        }
        
        static void Main()
        {
            Foo foo = new Foo();
            FooShow(foo);
        }
    }
}
