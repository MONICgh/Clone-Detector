namespace Palindrome
{
    public static class Palindrome
    {
        public static long ReverseNum(long x)
        {
            char[] revStr = x.ToString().ToCharArray();
            Array.Reverse(revStr);
            return long.Parse(new string(revStr));
        }
        public static bool IsPalindrome(long x)
        {
            return ReverseNum(x) == x;
        }

        public static (long, int) PalSeq(long palindrome)
        {
            if (!IsPalindrome(palindrome))
            {
                throw new ArgumentException("Argument isn't a palindrome.");
            }

            for (long start = 1; start < palindrome; start++)
            {
                long current = start;
                int step = 0;
                while (!IsPalindrome(current) && current < palindrome)
                {
                    current += ReverseNum(current);
                    step++;
                }
                if (current == palindrome)
                {
                    return (start, step);
                }
            }
            return (palindrome, 0);
        }
    }
}