namespace StringDistinction
{
    public class Solver
    {
        private bool Insert(string s, string t)
        {
            var n = s.Length;
            var i = 0;
            while (i < n && s[i] == t[i])
            {
                ++i;
            }

            if (i == n) return true;
            while (i < n)
            {
                if (s[i] != t[i + 1]) return false;
                ++i;
            }

            return true;
        }

        private bool Change(string s, string t)
        {
            var n = s.Length;
            var i = 0;
            while (i < n && s[i] == t[i])
            {
                ++i;
            }

            if (i == n) return true;
            i += 1;
            while (i < n)
            {
                if (s[i] != t[i]) return false;
                ++i;
            }

            return true;
        }

        public bool Check(string s, string t)
        {
            if (s.Length > t.Length)
            {
                (s, t) = (t, s);
            }

            if (s.Length + 1 < t.Length)
            {
                return false;
            }

            return s.Length == t.Length ? Change(s, t) : Insert(s, t);
        }
    }
}