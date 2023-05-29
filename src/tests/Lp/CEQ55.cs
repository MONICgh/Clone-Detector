using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace Lab11
{
    [TestClass]
    public class UnitTest1
    {
        event EventHandler onDispose = delegate { };
        internal class MyDisposable : IDisposable
        {
            int a;
            public MyDisposable(int i)
            {
                a = i;
            }
            public void Dispose()
            {}

            public override string ToString()
            {
                return a.ToString();
            }
        }
        [TestMethod]
        public void TooMuch()
        {
            DisposeCache cache = new DisposeCache(5, 1);
            cache.Add(new MyDisposable(0));
            cache.Add(new MyDisposable(1));
            cache.Add(new MyDisposable(2));
            cache.Add(new MyDisposable(3));
            cache.Add(new MyDisposable(4));
            // here it goes
            cache.Add(new MyDisposable(5));
            Console.WriteLine(cache.ToString());
        }


        [TestMethod]
        public void ExternalSignal()
        {
            DisposeCache cache = new DisposeCache(5, 1);
            // Did not found a better way
            cache.RegisterForFullGCNotification(handler => onDispose += handler);
            cache.Add(new MyDisposable(0));
            cache.Add(new MyDisposable(1));
            cache.Add(new MyDisposable(2));
            cache.Add(new MyDisposable(3));
            Thread.Sleep(10);
            onDispose(null, null);
            Console.WriteLine(cache.ToString());
        }
    }
}
