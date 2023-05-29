using System.Text;

namespace Factorization
{
    public static class Factorization
    {
        public static string ExpressFactors(int x)
        {
            int curDivisor = 2;
            StringBuilder sbFactorization = new StringBuilder();
            while (curDivisor * curDivisor <= x)
            {
                int power = 0;
                while (x % curDivisor == 0)
                {
                    power++;
                    x /= curDivisor;
                }

                if (power > 0 && sbFactorization.Length > 0)
                {
                    sbFactorization.Append(" x ");
                }
                if (power == 1)
                {
                    sbFactorization.Append(curDivisor);
                }
                if (power > 1)
                {
                    sbFactorization.Append(curDivisor.ToString() + "^" + power.ToString());
                }
                curDivisor++;
            }

            if (x != 1)
            {
                if (sbFactorization.Length > 0)
                {
                    sbFactorization.Append(" x ");
                }
                sbFactorization.Append(x);
            }
            return sbFactorization.ToString();
        }
    }
}