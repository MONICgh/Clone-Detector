using System;

namespace Integration;

public delegate double Function(double x);

public static class Integrator
{
    private const double Epsilon = 0.00001;

    public static double Integrate(Function f, double a, double b)
    {
        if (a > b)
        {
            double t = a;
            b = a;
            a = t;
        }
        double sum = 0;
        double x = a;
        
        while (x <= b - Epsilon)
        {
            x += Epsilon;
            sum += f(x) * Epsilon;
        }

        if (x < b)
        {
            sum += f(b) * Math.Abs(b - x);
        }

        return sum;
    }
}