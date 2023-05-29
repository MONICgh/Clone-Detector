using System.Collections.Generic;
using System.Linq;

namespace MaxMin;

public static class MaxiMinni
{
    // За квадрат только ради IEnumerable )
    static IEnumerable<ulong> allSwaps(ulong x)
    {
        var charX = x.ToString().ToCharArray();
        for (int i = 0; i < charX.Length; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                if (!(j == 0 && charX[i] == '0'))
                {
                    (charX[i], charX[j]) = (charX[j], charX[i]);
                    yield return ulong.Parse(string.Join("", charX));
                    (charX[i], charX[j]) = (charX[j], charX[i]);
                }
            }
        }
    }
    public static ulong[] MaxMin(ulong x)
    {
        var swaps = MaxiMinni.allSwaps(x);
        return new[] { swaps.Max(), swaps.Min() };
    }
}