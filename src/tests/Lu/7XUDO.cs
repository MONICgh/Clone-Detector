using System.Text;

namespace HW_09.Rationals;

public static class Rational
{
    public static string GetSolution(int a, int b)
    {
        if (a >= b)
        {
            throw new ArgumentException($"The first argument {a} should be less than the second argument {b}");
        }
        var answer = new StringBuilder("0.");
        var remains = new List<int> { a };

        var withPeriod = false;
        while (a != 0)
        {
            a *= 10;
            answer.Append(a / b);
            a %= b;

            if (a == 0)
                continue;
            if (remains.Contains(a))
            {
                withPeriod = true;
                break;
            }
            remains.Add(a);
        }
        if (!withPeriod)
            return answer.ToString();

        var stringResult = answer.ToString();
        var separationPoint = remains.IndexOf(a) + 2;
        return stringResult[..separationPoint] + "(" + stringResult[separationPoint..] + ")";
    }
}
