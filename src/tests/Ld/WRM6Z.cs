namespace Task3;

public class SimplifyUtil
{
    public static string Simplify(string arg)
    {
        var splitted = arg.Split("/");
        var numerator = long.Parse(splitted[0]);
        var denominator = long.Parse(splitted[1]);
        var min = Math.Min(numerator, denominator);
        for (long i = 2; i * i <= min; i++)
        {
            while (numerator % i == 0 && denominator % i == 0)
            {
                numerator /= i;
                denominator /= i;
            }

            if (min % i == 0)
            {
                var div = min / i;
                while (numerator % div == 0 && denominator % div == 0)
                {
                    numerator /= div;
                    denominator /= div;
                }
            }
        }

        if (denominator == 1)
        {
            return numerator.ToString();
        }
        else
        {
            return numerator.ToString() + "/" + denominator.ToString();
        }
    }
}