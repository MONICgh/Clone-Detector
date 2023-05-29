namespace OneSymbolDiff
{
    public class OneSymbolDiff
    {
        public static bool oneSymbolDiff(string s, string t)
        {
            if (Math.Abs(s.Length - t.Length) > 1)
            {
                return false;
            }

            if (s.Length < t.Length)
            {
                (t, s) = (s, t);
            }

            int pref = 0;
            int suf = 0;
            while (pref < t.Length && s[pref] == t[pref])
            {
                pref++;
            }
            while (suf < t.Length && s[s.Length - 1 - suf] == t[t.Length - 1 - suf])
            {
                suf++;
            }

            if (s.Length == t.Length)
            {
                return suf + pref >= t.Length - 1;
            }
            else
            {
                return suf + pref >= t.Length;
            }
        }
    }
}