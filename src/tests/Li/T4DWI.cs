namespace RepeatString
{
    public class Substring
    {
        public static string LongestRepeatSubstring(string s)
        {
            for (int len = s.Length; len > 0; len--)
            {
                HashSet<int> substr = new();
                for (int lef = 0; lef <= s.Length - len; lef++)
                {
                    int hash = s.Substring(lef, len).GetHashCode();
                    if (substr.Contains(hash))
                    {
                        return s.Substring(lef, len);
                    }
                    substr.Add(hash);
                }
            }
            return "";
        }
    }
}