using System;

namespace Integral
{
    public delegate double Function(double x);
    
    public class IntegralCalculator
    {
        private readonly int _steps;
        public IntegralCalculator(int steps = 100000000)
        {
            _steps = steps;
        }

        public double Integrate(Function f, double a, double b)
        {
            if (a > b)
            {
                throw new ArgumentException("a must not be greater than b!");
            }
            double ans = 0;
            var step = (b - a) / _steps;
            while (a <= b)
            {
                a += step;
                ans += f(a) * step;
            }

            return ans;
        }
    }
}