using System.Collections.Specialized;

namespace HW_05.Factorizer;

public class Factorizer
{
    public static string Factorize(int n)
    {
        var data = new Dictionary<int, int>();
        for (var i = 2; i * i <= n; i++)
        {
            while (n % i == 0)
            {
                n /= i;
                if (!data.ContainsKey(i))
                    data.Add(i, 0);
                data[i] += 1;
            }
        }
        if (n != 1)
        {
            if (!data.ContainsKey(n))
                data.Add(n, 0);
            data[n] += 1;
        }
        return PrintDict(data);
    }

    private static string PrintDict(Dictionary<int, int> data)
    {
        var entries = from entry in data orderby entry.Key select entry;
        var isFirst = true;
        var answer = "";
        foreach (var keyValuePair in entries)
        {
            if (!isFirst)
            {
                answer += " x ";
            }
            else
            {
                isFirst = false;
            }
            if (keyValuePair.Value == 1)
            {
                answer += keyValuePair.Key;
            }
            else
            {
                answer += keyValuePair.Key + "^" + keyValuePair.Value;
            }

        }
        return answer;
    }
}
