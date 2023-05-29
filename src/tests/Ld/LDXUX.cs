using System;
using System.Text.RegularExpressions;

namespace SimplifySpace;

static class Program
{
    private static int Gcd(int a, int b)
    {
        while (a != 0 && b != 0)
        {
            if (a > b)
                a %= b;
            else
                b %= a;
        }

        return a | b;
    }

    public static string Simplify(string arg)
    {
        var regex = new Regex(@"\d+/\d+");
        if (!regex.IsMatch(arg))
        {
            throw new ArgumentException("Incorrect argument");
        }
        var xs = arg.Split("/", count: 2);
        var numerator = int.Parse(xs[0]);
        var denominator = int.Parse(xs[1]);

        var gcd = Gcd(numerator, denominator);
        if (denominator == gcd)
        {
            return $"{numerator/gcd}";
        }
        else
        {
            return $"{numerator/gcd}/{denominator/gcd}";
        }
    }
}
