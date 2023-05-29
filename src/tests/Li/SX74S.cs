using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;

namespace Application
{
    class Task2
    {
        static List<ExceptionDispatchInfo> exceptions = new List<ExceptionDispatchInfo>();

        static float Division(float x, float y)
        {
            if (y == 0)
            {
                throw new DivideByZeroException("Division: y is 0");
            }
            return x / y;
        }

        static void SomeFun()
        {
            try
            {
                var res0 = Division(2, 1);
                Console.WriteLine(res0);
                var res1 = Division(1, 0);
                Console.WriteLine(res1);
            }
            catch (Exception e)
            {
                exceptions.Add(ExceptionDispatchInfo.Capture(e));
            }
        }

        static void Main()
        {
            SomeFun();
            if (exceptions.Count() > 0)
            {
                exceptions.First().Throw();
            }
            Console.WriteLine("run without exception");
        }
    }
}
