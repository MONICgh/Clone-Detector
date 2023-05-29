using System.Text;

namespace FibonacciStrings
{
    public class Fibonacci
    {
        public static string FibonacciBuild(int n)
        {
            if (n < 2)
            {
                return "invalid";
            }

            string[] words = new string[n];
            string cur = "b";
            string nxt = "a";

            for (int i = 0; i < n; i++)
            {
                words[i] = cur;
                string nxt2 = nxt + cur;
                cur = nxt;
                nxt = nxt2;
            }
            return string.Join(", ", words);
        }
    }
}