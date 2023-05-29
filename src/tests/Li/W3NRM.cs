using System.Text;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Serialization;

namespace HW_08;

public static class StringSolver
{
    public static class Serializer
    {
        public static byte[] Serialize(string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }

        public static string Deserialize(byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }
    }

    public static bool DiffersInOneSymbol(string s1, string s2)
    {
        while (true)
        {
            if (s1.Length == 0 && s2.Length == 1)
                return true;
            if (s2.Length == 0 && s1.Length == 1)
                return true;
            if (s1.First() != s2.First())
                return s1 == s2[1..] || s2 == s1[1..] || s2[1..] == s1[1..];
            s1 = s1[1..];
            s2 = s2[1..];
        }
    }

    public static string Merger(string s1, string s2)
    {
        var f = s1.Split(" ");
        var s = s2.Split(" ");

        string InternalMerger(string[] a, string[] b)
        {
            if (a.Length == 0)
            {
                return string.Join(' ', b);
            }
            if (b.Length == 0)
            {
                return string.Join(' ', a);
            }
            var merged = InternalMerger(a[1..], b[1..]);
            if (merged.Length != 0)
                merged = " " + merged;
            if (a.First() == b.First())
            {
                return a.First() + merged;
            }
            return a.First() + " " + b.First() + merged;
        }

        return InternalMerger(f, s);
    }

    public static string Sorter(string s)
    {
        var data = s.ToList();
        data.Sort((c1, c2) =>
        {
            if (char.IsNumber(c1) && char.IsNumber(c2))
            {
                return c1.CompareTo(c2);
            }
            if (char.IsNumber(c1))
            {
                return 1;
            }
            if (char.IsNumber(c2))
            {
                return -1;
            }
            if (char.ToLower(c1) == char.ToLower(c2))
            {
                return -c1.CompareTo(c2);
            }
            return char.ToLower(c1).CompareTo(char.ToLower(c2));
        });
        return string.Join("", data);
    }

    public static string FibonacciStr(int n)
    {
        if (n < 2)
        {
            return "invalid";
        }

        var fibStrings = new List<string> { "b", "a" };
        var n1 = n - 2;
        while (n1 != 0)
        {
            fibStrings.Add(fibStrings[^1] + fibStrings[^2]);
            n1 -= 1;
        }
        return string.Join(", ", fibStrings);
    }


    public static string MostFrequentSubstr(string s)
    {
        var mapCounter = new Dictionary<string, int>();

        for (var i = 0; i < s.Length; i++)
        {
            for (var j = i; j < s.Length; j++)
            {
                var substring = s.Substring(i, j - i + 1);
                mapCounter[substring] = mapCounter.GetValueOrDefault(substring, 0) + 1;
            }
        }
        return mapCounter.Where(pair => pair.Value > 1).Select(pair => pair.Key).OrderByDescending(str => str.Length).First();
    }
}
