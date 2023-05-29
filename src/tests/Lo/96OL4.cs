using System;
using System.Threading;

namespace RaceCondition
{
    class Program
    {
        static int i = 0;          
        static void MakeIt1()
        {
            i = 1;
            Console.WriteLine(i);
        }

        static void MakeIt2()
        {
            i = 2;
            Console.WriteLine(i);
        }

        static void Main(string[] args)
        {
            var t1 = new Thread(MakeIt1);
            var t2 = new Thread(MakeIt2);
            t1.Start();
            t2.Start();
            Console.WriteLine(i);       //результат будет меняться с запусками
        }
    }
}
