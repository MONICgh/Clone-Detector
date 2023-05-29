using System;
using System.Linq;
using System.Reflection;

namespace Lab10
{
    internal class Program
    {
        [Custom("A", 4, "Aab", "a", "b")]
        internal class HealthScore
        {
            [Custom("B", 3, "B")]
            public HealthScore() { }

            [Custom("C", 0, "Cabc", "a", "b", "c")]
            public static long CalcScoreData()
            {
                return 0;
            }
            public static void DoSomething()
            {
                // Nah
            }
        }


        static void Main(string[] args)
        {
            // Class
            var classAttributes = typeof(HealthScore).GetCustomAttributes();
            Console.Write(typeof(HealthScore).GetTypeInfo().Name);
            Console.Write(" ");

            foreach (var i in classAttributes)
                Console.WriteLine(i);

            // Constructor
            foreach (var ctor in typeof(HealthScore).GetTypeInfo().GetConstructors())
            {
                Console.Write(ctor.Name);
                foreach (var attribute in ctor.GetCustomAttributes())
                {
                    Console.Write(": ");
                    Console.Write(attribute);
                }
                Console.WriteLine("");
            }

            // Methods
            foreach (var method in typeof(HealthScore).GetTypeInfo().GetMethods())
            {
                Console.Write(method.Name);

                foreach(var attribute in method.GetCustomAttributes())
                {
                    Console.Write(": ");
                    Console.Write(attribute);
                }
                Console.WriteLine("");
            }
        }
    }
}
