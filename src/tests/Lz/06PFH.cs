namespace Task3;

public class SunLoungers
{
    public static int Apply(string s)
    {
        s = "0" + s;
        bool flag = true;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '1')
            {
                flag = false;
            }
        }

        if (!flag)
        {
            s = s + "0";
        }

        int c = 0;
        int ans = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '1')
            {
                ans += c / 2;
                c = 0;
            }
            else
            {
                c += 1;
            }
        }

        ans += c / 2;
        return ans;
    } 
}