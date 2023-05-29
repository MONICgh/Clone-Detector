using System.Text;

namespace Task5;

public static class Rational
{
    public static string Apply(int a, int b)
    {
        if (a % b == 0)
        {
            return (a / b).ToString();
        }

        var mods = new List<int>();
        var divs = new List<int>();

        var firstInPeriod = -1;
        while (a % b != 0)
        {
            if (mods.Contains(a % b))
            {
                firstInPeriod = a % b;
                break;
            }

            divs.Add(a / b);
            mods.Add(a % b);

            a = (a % b) * 10;
        }
        
        divs.Add(a / b);

        var ans = new StringBuilder();
        ans.Append(divs[0] + ".");
        
        if (firstInPeriod == -1)
        {
            for (int i = 1; i < divs.Count; i++)
            {
                ans.Append(divs[i]);
            }

            return ans.ToString();
        }

        int t = 1;
        while (mods[t - 1] != firstInPeriod)
        {
            ans.Append(divs[t]);
            t++;
        }

        ans.Append("(");
        for (; t < divs.Count; t++)
        {
            ans.Append(divs[t]);
        }

        ans.Append(")");

        return ans.ToString();
    }
}