namespace Delegates;

public delegate double Function(double x);

internal static class Program
{
    static double Integrate(Function f, double a, double b)
    {
        const int segmentsCount = 100000000;
        var result = 0.0;
        var step = (b - a) / segmentsCount;

        for (var i = 0; i < segmentsCount; i++)
        {
            result += f(a + step * i) * step;
        }

        return result;
    }
    
    public static void Main()
    {
        var id = new Function(x => x);
        var sin = new Function(Math.Sin);
        var cos = new Function(Math.Cos);
        var exp = new Function(Math.Exp);

        Console.WriteLine(Integrate(id, 0, 1));
        Console.WriteLine(Integrate(id, -1, 1));
        Console.WriteLine(Integrate(sin, 0, Math.PI));
        Console.WriteLine(Integrate(cos, 0, Math.PI));
        Console.WriteLine(Integrate(exp, 0, 1));
    } 
}
