using System;

namespace Palindrome
{
    class Palindrome
    {

        private static int Reverse(int value)
        {
            var valueAsArray = value.ToString().ToCharArray();
            Array.Reverse(valueAsArray);
            return Convert.ToInt32(new string(valueAsArray));
        }

        private static int? FindNumberOfSteps(int seed, int pal)
        {
            int steps = 0;
            int currentValue = seed;
            while (currentValue < pal)
            {
                currentValue += Reverse(currentValue);
                steps++;
            }

            if (currentValue == pal)
            {
                return steps;
            }

            return null;
        }
        
        public static Tuple<int, int> PalSeq(int pal)
        {
            int? steps = 0;
            int seed = 0;

            for (int i = 1; i <= pal; i++)
            {
                seed = i;
                steps = FindNumberOfSteps(seed, pal);
                if (steps != null)
                {
                    return new Tuple<int, int>(seed, (int)steps);
                }
            }

            return new Tuple<int, int>(0, 0);
        }
    }
}

