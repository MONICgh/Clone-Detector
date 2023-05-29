using System;
using System.Collections.Generic;

namespace HW01.CollectWater
{
    public static class WaterCollectorSolver
    {
        public static int Solve(IReadOnlyList<int> numbers)
        {
            var left = 0;
            var right = numbers.Count - 1;
            var maxLeft = numbers[left];
            var maxRight = numbers[right];
            var answerSum = 0;
            while (left < right)
            {
                int currentHeight;
                if (numbers[left] < numbers[right])
                {
                    left++;
                    maxLeft = Math.Max(maxLeft, numbers[left]);
                    currentHeight = numbers[left];
                }
                else
                {
                    right--;
                    maxRight = Math.Max(maxRight, numbers[right]);
                    currentHeight = numbers[right];
                }
                answerSum += Math.Max(0, Math.Min(maxLeft, maxRight) - currentHeight);
            }
            return answerSum;
        }
    }
}
