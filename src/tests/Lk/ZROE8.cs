namespace HW_04.Integral;

public delegate double Function(double x);

public static class Integrator
{
    private const double Delta = 0.00001;

    public static double Integrate(Function f, double a, double b)
    {
        if (a > b)
            return -Integrate(f, b, a);

        // a <= b
        double sum = 0;
        for (var x = a; x <= b; x += Delta)
        {
            sum += f(x) * Math.Min(Delta, b - x);
        }
        return sum;
    }
}
