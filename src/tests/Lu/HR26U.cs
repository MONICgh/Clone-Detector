using System.Collections.Generic;
using System.Linq;

namespace Rational;

public static class RationalNumber
{
    public static string Rational(int a, int b)
    {
        var digits = new List<int>();
        var history = new List<int>();

        while (!history.Contains(a))
        {
            history.Add(a);
            a *= 10;
            while (a < b)
            {
                a *= 10;
                digits.Add(0);
            }
            
            digits.Add(a / b);
            a -= a / b * b;

            if (a == 0)
            {
                break;
            }
        }

        if (a == 0)
        {
            return $"0.{string.Join("", digits)}";
        }

        var cycleStart = history.IndexOf(a);
        var prefix = string.Join("", digits.Take(cycleStart));
        var cycle = string.Join("", digits.Skip(cycleStart));
        return $"0.{prefix}({cycle})";
    }
}