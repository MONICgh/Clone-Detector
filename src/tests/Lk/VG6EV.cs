using System;

namespace task3
{
    public delegate double Function(double x);
    class Program
    {
        public static double Integrate(Function f, double a, double b)
        {
            const double epsilon = 0.0001;
            double sign = 1, ans = 0;

            if (a > b)
            {
               (a, b) = (b, a);
                sign = -1;
            }
            while (a < b)
            {
                ans += f(a) * epsilon;
                a += epsilon;
            }
            return ans * sign;

        }
        static void Main(string[] args)
        {
            Function sqr = (x) => x * x;
            Function cos = (x) => Math.Cos(x);
            Function tanh = (x) => Math.Tanh(x);
            Console.WriteLine(Integrate(sqr, 2, 0));
            Console.WriteLine(Integrate(cos, 0, 2));
            Console.WriteLine(Integrate(tanh, -1, 1));
        }
    }
}