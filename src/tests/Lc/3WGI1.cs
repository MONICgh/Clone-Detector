using System.Reflection;

namespace Application
{
    public class FooBar { 
        private int n;
        ManualResetEventSlim mre1 = new ManualResetEventSlim(true); 
        ManualResetEventSlim mre2 = new ManualResetEventSlim(false); 
        
        public FooBar(int n) 
        {
            this.n = n; 
        }
        
        public void Foo(Action printFoo) 
        {
            for (int i = 0; i < n; i++) 
            {
                mre1.Wait();
                // Thread.Sleep(50);
                // printFoo() outputs "foo". Do not change or remove this line.
                printFoo();
                mre2.Set();
                mre1.Reset();
            }
        }
        
        public void Bar(Action printBar) 
        {
            for (int i = 0; i < n; i++) 
            {
                mre2.Wait();
                // Thread.Sleep(50);
                // printBar() outputs "bar". Do not change or remove this line. printBar();
                printBar();
                mre1.Set();
                mre2.Reset();
            }
        }
    }
    
    class Task3
    {
        static void Main()
        {
            FooBar fooBar = new(10);
            Thread threadA = new Thread(() => fooBar.Foo(() => Console.Write("foo")));
            Thread threadB = new Thread(() => fooBar.Bar(() => Console.Write("bar")));
            threadA.Start();
            threadB.Start();
            threadA.Join();
            threadB.Join();
        }
    }
}
