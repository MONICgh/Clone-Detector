using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    delegate double Func(double x);

    class Integrating
    {
        public double Integrate(Func f, double x, double y)
        {
            double  ans = 0, eps = 0.001;
            if (x > y)
            {
                return Integrate(f, y, x) * (-1);
            }
            while (x < y)
            {
                ans += f(x) * eps;
                x += eps;
            }
            return Math.Round(ans,2);
        }
    }
    class Program
    {
        private const int V = 3;

        static void Main(string[] args)
        {
            Integrating I = new();

            Console.WriteLine(I.Integrate(x => x * x, 0, 4));
            Console.WriteLine(I.Integrate(x => Math.Sin(x), 0, 2*Math.PI));
            Console.WriteLine(I.Integrate(x => Math.Tan(x), 0, Math.PI / V));
            Console.WriteLine(I.Integrate(x => Math.Tan(x), 1, 0));
        }
    }
}