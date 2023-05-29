using System;
using System.Collections.Generic;
using System.Threading;

namespace SleepSort
{
    class Program
    {
        static void printStr(string s)
        {
            Thread.Sleep(100 * s.Length);
            Console.WriteLine(s);
        }

        static void Test(string[] str)
        {
            var threads = new Thread[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                int n = i;
                threads[n] = new Thread(() => printStr(str[n]));
                threads[n].Start();
            }
            foreach (var thr in threads)
                thr.Join();

        }

        static List<string> sorted = new List<string>();
        static void printStr1(string s)
        {
            Thread.Sleep(100 * s.Length);
            lock (sorted)
            {
                sorted.Add(s);
            }
        }

        static void Test2(string[] str)
        {
            var threads = new Thread[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                int n = i;
                threads[n] = new Thread(() => printStr1(str[n]));
                threads[n].Start();
            }
            foreach (var thr in threads)
                thr.Join();
            foreach (var w in sorted)
                Console.Write($"{w} ");
        }

        static void Main(string[] args)
        {
            Test(new string[] { "a", "ab", "abc", "GDR", "KTTS", "KBU", "well", "B8" });
            Test2(new string[] { "a", "ab", "abc", "GDR", "KTTS", "KBU", "well", "B8" });
        }
    }
}
