using System;
using System.Runtime.ExceptionServices;

namespace Exceptio
{
    class exceptio
    {
        static void reciprocal(ref float[] arr)
        {
            float[] arrReserve = new float[arr.Length];
            for (int i = 1; i < arr.Length; i++)
            {
                arrReserve[i] = arr[i];
            }
                for (int i = 1; i < arr.Length; i++)
            {
                if (Math.Abs(arr[i]) <= 0.1)
                {
                    ExceptionDispatchInfo disInf = ExceptionDispatchInfo.Capture(new DivideByZeroException($"arr[{i}] is too small"));
                    for (int j = 1; j < i; j++)
                        arr[j] = arrReserve[j];
                    disInf.Throw();
                }
                arr[i] = 1/ arr[i];
            }
        }

        static void Main(string[] args)
        {
            var a = new float[] { 2, 3, 4 };
            var b = new float[] { 4, 0 };
            try
            {
                reciprocal(ref a);
                reciprocal(ref b);
            }
            catch
            {
                Console.Write("a: ");
                foreach (var i in a)
                    Console.Write($"{i} ");
                Console.WriteLine();
                Console.Write("b: ");
                foreach (var i in b)
                    Console.Write($"{i} ");
            }

        }
    }
}