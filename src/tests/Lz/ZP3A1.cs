using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Factor;

public static class Factor
{
    public static string ExpressFactor(int number)
    {
        List<string> dividers = new List<string>();

        int i = 2;
        int degree = 0;
        while (number > 1)
        {
            if (number % i == 0)
            {
                degree++;
                number /= i;
            }
            
            if (number % i != 0)
            {
                if (degree == 1)
                {
                    dividers.Add($"{i}");
                }
                else if (degree > 1)
                {
                    dividers.Add($"{i}^{degree}");
                }

                i++;
                degree = 0;
            }
        }

        return string.Join(" x ", dividers);
    }
}