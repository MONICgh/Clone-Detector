using System.Text;

namespace Rational
{
    public static class Period
    {
        public static string Rational(int a, int b)
        {
            Dictionary<int, int> remainders = new();
            StringBuilder sb = new();
            sb.Append("0.");

            int rem = a;
            for (int i = 1; ; i++)
            {
                if (rem == 0)
                {
                    break;
                }
                if (remainders.ContainsKey(rem))
                {
                    int position = remainders[rem];
                    sb.Insert(position + 1, '(');
                    sb.Append(')');
                    break;
                }
                remainders.Add(rem, i);

                a = rem * 10;
                int div = a / b;
                rem = a % b;

                sb.Append(div);
            }
            return sb.ToString();
        }
    }
}