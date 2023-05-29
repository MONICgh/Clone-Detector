using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Inter
{
    interface plus1
    {
        public int pl(int a);
    }

    interface plus2
    {
        public int pl(int a);
    }

    abstract class plussio
    {
        public abstract int pl(int a);
    }

    internal class MultiPlus : plussio, plus1, plus2
    {
        int plus1.pl(int a)
        {
            return a + 1;
        }

        int plus2.pl(int a)
        {
            return a + 2;
        }

        public override int pl(int a)
        {
            return a + 10;
        }
    }

    class Program {
        static void Main(string[] args)
        {
            var p = new MultiPlus();
            int v = 3;

            Console.WriteLine(p.pl(v));
            Console.WriteLine(((plus1)p).pl(v));
            Console.WriteLine(((plus2)p).pl(v));
        }
    }
}