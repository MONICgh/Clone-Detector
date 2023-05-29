using System;

namespace Application
{
    delegate double Function(double x);

    class MathFunctions
    {
        public event Function func = null;

        public double Integrate(double a, double b, double dx = 0.001) => Integrate(func, a, b, dx);

        public double Integrate(Function f, double a, double b, double dx = 0.001)
        {
            double sum = 0;
            if (a > b) dx = -dx;
            double x = a;
            for (; x < b; x += dx)
            {
                sum += f(x + dx / 2) * dx;
            }
            sum += f(x + (b - x) / 2) * (b - x);
            return sum;
        }
    }

    class Task3
    {
        static int Main()
        {
            var m = new MathFunctions();
            Function f = (double x) => x * x;
            m.func += f;
            Console.WriteLine(m.Integrate(-1, 1));
            m.func -= f;
            f = (double x) => x * x * x;
            m.func += f;
            Console.WriteLine(m.Integrate(-1, 1));
            m.func -= f;
            Console.WriteLine(m.Integrate(x => Math.Exp(x), 0, 1));
            return 0;
        }
    }
}
