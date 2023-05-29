public delegate double Function(double x);

namespace Delegates
{
    public class Program
    {
        static readonly int NUM_STEP = 100000;
        public static double Integrate(Function f, double a, double b)
        {
            double len_step = (b - a) / NUM_STEP;
            double integral = 0;
            for (int i = 0; i < NUM_STEP; i++)
            {
                double x1 = a + len_step * i;
                double x2 = a + len_step * (i + 1);
                double y = (f(x1) + f(x2)) / 2;
                integral += y * len_step;
            }
            return integral;
        }
    }
}