namespace Task4;

public class ExpressFactors
{
    public static string Apply(int a)
    {
        var divs = new List<int>();
        int t = 2;
        while (t <= a)
        {
            if (a % t == 0)
            {
                divs.Add(t);
                a /= t;
            }
            else
            {
                t++;
            }
        }

        string ans = "";
        t = 1;
        int last = divs[0];
        for (int i = 1; i < divs.Count; i++)
        {
            if (divs[i] == last)
            {
                t++;
            }
            else
            {
                if (t == 1)
                {
                    ans += last.ToString() + " x ";
                } else if (t > 1)
                {
                    ans += last.ToString() + "^" + t + " x ";
                }

                last = divs[i];
                t = 1;
            }
        }
        
        if (t == 1)
        {
            ans += last.ToString() + " x ";
        } else if (t > 1)
        {
            ans += last.ToString() + "^" + t + " x ";
        }
        
        ans = ans.Substring(0, ans.Length - 3);
        return ans;
    }
}