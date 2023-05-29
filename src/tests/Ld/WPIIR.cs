namespace Fraction
{
    public static class Fraction
    {
        private static int GCD(int x, int y)
        {
            if (x == 0)
            {
                return y;
            }
            return GCD(y % x, x);
        }
        public static string Simplify(string arg)
        {
            int pos = arg.IndexOf('/');
            if (pos == -1)
            {
                throw new ArgumentException("Fraction hasn't symbol /.");
            }

            string numeratorStr = arg.Substring(0, pos);
            string denominatorStr = arg.Substring(pos + 1);
            
            int numerator, denominator;
            bool successNum = int.TryParse(numeratorStr, out numerator);
            bool successDen = int.TryParse(denominatorStr, out denominator);

            if (!successNum || !successDen)
            {
                throw new ArgumentException("Can't parse numbers for numerator or denominator.");
            }

            int d = GCD(numerator, denominator);
            numerator /= d;
            denominator /= d;

            string totalFraction;
            if (denominator == 1)
            {
                totalFraction = numerator.ToString();
            }
            else
            {
                totalFraction = numerator.ToString() + "/" + denominator.ToString();
            }
            return totalFraction;
        }
    }
}