namespace Task6;

public static class MaxiMinni
{
    public static ulong[] Apply(ulong number)
    {
        var digits = new List<ulong>();
        var bestMinniDigits = new List<ulong>();
        var bestMaxiDigits = new List<ulong>();
        var originalDigits = new List<ulong>();
        if (number == 0)
        {
            return new ulong[] { 0, 0 };
        }

        var numberOfZeros = 0;
        
        while (number > 0)
        {
            if (number % 10 == 0)
            {
                numberOfZeros++;
            }
            else
            {
                digits.Add(number % 10);
            }
            originalDigits.Add(number % 10);
            number /= 10;
        }
        
        digits.Sort();

        ulong bestMaxi = 0;
        for (int i = digits.Count() - 1; i >= 0; i--)
        {
            bestMaxi *= 10;
            bestMaxi += digits[i];
        }
        
        ulong bestMinni = digits[0];
        for (int i = 0; i < numberOfZeros; i++)
        {
            bestMinni *= 10;
            bestMaxi *= 10;
        }

        for (int i = 1; i < digits.Count(); i++)
        {
            bestMinni *= 10;
            bestMinni += digits[i];
        }

        while (bestMaxi > 0)
        {
            bestMaxiDigits.Add(bestMaxi % 10);
            bestMaxi /= 10;
        }

        while (bestMinni > 0)
        {
            bestMinniDigits.Add(bestMinni % 10);
            bestMinni /= 10;
        }

        originalDigits.Reverse();
        bestMaxiDigits.Reverse();
        bestMinniDigits.Reverse();
        
        int sl = -1, sr = -1;
        for (int i = 0; i < originalDigits.Count(); i++)
        {
            if (sl == -1 && originalDigits[i] != bestMaxiDigits[i])
            {
                sl = i;
            }
            else if (sl != -1)
            {
                if (sr == -1)
                {
                    sr = i;
                } else if (originalDigits[i] > originalDigits[sr])
                {
                    sr = i;
                }
            }
        }

        var maxi = 0ul;
        for (int i = 0; i < originalDigits.Count(); i++)
        {
            maxi *= 10;
            if (i == sl && sr != -1)
            {
                maxi += originalDigits[sr];
            }
            else if (i == sr)
            {
                maxi += originalDigits[sl];
            }
            else
            {
                maxi += originalDigits[i];                
            }
        }

        sl = -1;
        sr = -1;
        for (int i = 0; i < originalDigits.Count(); i++)
        {
            if (sl == -1 && originalDigits[i] != bestMinniDigits[i])
            {
                sl = i;
            }
            else if (sl != -1)
            {
                if (sr == -1)
                {
                    sr = i;
                } else if (originalDigits[i] < originalDigits[sr] && (sl != 0 || originalDigits[i] != 0))
                {
                    sr = i;
                }
            }
        }


        var minni = 0ul;
        for (int i = 0; i < originalDigits.Count(); i++)
        {
            minni *= 10;
            if (i == sl && sr != -1)
            {
                minni += originalDigits[sr];
            }
            else if (i == sr)
            {
                minni += originalDigits[sl];
            }
            else
            {
                minni += originalDigits[i];                
            }
        }

        return new ulong[] { maxi, minni };
    } 
}