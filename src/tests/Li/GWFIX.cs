namespace Task6;

public static class StringyFib
{
    public static string Apply(int n)
    {
        if (n < 2)
        {
            return "invalid";
        }

        string s0 = "b";
        string s1 = "a";
        string ans = "b, a";
        for (var i = 2; i < n; i++)
        {
            string s2 = s1 + s0;
            s0 = s1;
            s1 = s2;
            ans += ", " + s1;
        }

        return ans;
    }
}