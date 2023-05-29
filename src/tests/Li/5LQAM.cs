namespace Task3;

public static class StringDifference
{
    public static bool Apply(string s, string p)
    {
        int l = 0;
        int r = 0;
        bool flag = false;
        while (l < s.Length && r < p.Length)
        {
            if (s[l] != p[r])
            {
                if (flag)
                    return false;
                flag = true;
                if (s.Length < p.Length)
                    r++;
                else if (p.Length < s.Length)
                    l++;
                else
                {
                    l++;
                    r++;
                }
                continue;
            }

            l++;
            r++;
        }

        if ((s.Length - l) == (p.Length - r))
            return true;
        if ((s.Length - l - p.Length + r == 1 || s.Length - l - p.Length + r == -1) && !flag)
            return true;

        return false;
    }
}