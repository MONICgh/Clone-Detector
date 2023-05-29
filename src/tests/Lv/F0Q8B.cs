using System;
using System.Linq;

namespace Concatenation
{
    struct Object
    {
        string name;
        public string Name => name;
        public Object(string name)
        {
            this.name = name;
        }
    }

    class Concat
    {
        public static string DoConcatination(Object[] objects, string delimeter)
        {   
            return (from o in objects select o.Name)
                .Skip(3)
                .Aggregate((x, y) => x + delimeter + y);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var objects = new Object[] { new Object("Arnold"), new Object("Boris"), new Object("Catherine"), new Object("Dimitry"), new Object("Egor"), new Object("Fedor") };
            Console.WriteLine(Concat.DoConcatination(objects, " = "));
        }
    }
}