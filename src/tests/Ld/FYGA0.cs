using System;

namespace HW03
{
    public static class SimplifiedFractionSolver
    {
        private static int Gcd(int a, int b)
        {
            while (b != 0)
            {
                var a1 = a;
                a = b;
                b = a1 % b;
            }
            return a;
        }

        public static string Simplify(string arg)
        {
            var strings = arg.Split('/');
            if (strings.Length != 2)
            {
                throw new ArgumentException("Wrong fraction format");
            }
            try
            {
                var a = int.Parse(strings[0]);
                var b = int.Parse(strings[1]);
                var gcd = Gcd(a, b);
                a /= gcd;
                b /= gcd;
                if (b == 1)
                    return a.ToString();
                return a + "/" + b;
            }
            catch (Exception e)
            {
                throw new ArgumentException("Numbers can't be parsed: " + e.Message);
            }
        }
    }
}
