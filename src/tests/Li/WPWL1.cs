bool SingleDiff(string s1, string s2)
{
    if (Math.Abs(s1.Length - s2.Length) > 1)
    {
        return false;
    }

    if (s1.Length == s2.Length)
    {
        var difCnt = 0;
        for (var i = 0; i < s1.Length; i++)
        {
            if (s1[i] != s2[i])
            {
                difCnt++;
            }
        }

        return difCnt == 1;
    }

    bool passed = false;
    var p1 = 0;
    var p2 = 0;
    while (p1 < s1.Length && p2 < s2.Length)
    {
        if (s1[p1] != s2[p2])
        {
            if (passed)
            {
                return false;
            }

            if (s1.Length > s2.Length)
            {
                p1++;
            }
            else
            {
                p2++;
            }
            
            passed = true;
            continue;
        }

        p1++;
        p2++;
    }

    return true;
}

Console.WriteLine(SingleDiff("abc", "ab"));
Console.WriteLine(SingleDiff("ab", "abc"));
Console.WriteLine(SingleDiff("ac", "abc"));
Console.WriteLine(SingleDiff("abc", "ac"));
Console.WriteLine(SingleDiff("abc", "abd"));
Console.WriteLine(SingleDiff("abc", "acc"));

Console.WriteLine(SingleDiff("abc", "aa"));
Console.WriteLine(SingleDiff("aa", "abc"));
Console.WriteLine(SingleDiff("ac", "abbc"));
Console.WriteLine(SingleDiff("ac", "ac"));
