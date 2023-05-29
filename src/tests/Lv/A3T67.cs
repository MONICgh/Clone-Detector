using System;
using System.Linq;

namespace LongNames
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

    class Program
    {
        static void Main(string[] args)
        {
            var objects = new Object[] { new Object("Arnold"), new Object("Boris"), new Object("Catherine"), new Object("Dimitry"), new Object("Egor"), new Object("Fedor") };
            var pos = -1;
            var ans = (from o in objects select o.Name)
                .Where(x => {
                    pos++;
                    return x.Length > pos;
                });
            Console.WriteLine(ans.Aggregate((x, y) => x + ", " + y));
        }
    }
}
