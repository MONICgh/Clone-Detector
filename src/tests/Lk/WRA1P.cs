namespace Task3;

public delegate double F(double x);

public class Integrator
{
    public static double Integrate(F f, double a, double b)
    {
        var result = 0.0;
        for (double i = a; i < b; i += 0.001)
        {
            var step = b - i < 0.001 ? b - i : 0.001;
            result += f(i) * step;
        }

        return result;
    }
}