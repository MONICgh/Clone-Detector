using System;
using System.Threading;

namespace Lab14
{
    public class Foo
    {
        Object keyFirst = new object();
        Object keySecond = new object();
        int a = 0;
        public static void print(string s)
        {
            Console.Write(s);
        }
        public void first() 
        {
            lock (keyFirst)
            {
                print("first");
                a = 1;
                Monitor.Pulse(keyFirst);
            }
        }
        public void second() 
        {
            lock (keyFirst)
            {
                while(a < 1)
                    Monitor.Wait(keyFirst);
                lock (keySecond)
                {
                    print("second");
                    a = 2;
                    Monitor.Pulse(keySecond);
                }
            }
        }
        public void third()
        {
            lock (keySecond)
            {
                while (a < 2)
                {
                    Monitor.Wait(keySecond);
                }
                print("third");
                a = 3;
            }
        }
    }
}
