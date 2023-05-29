using System;
using System.Collections.Generic;

namespace RainWaterSolveTool
{
    public class RainWaterSolver
    {
        public int Solve(List<int> heights)
        {
            var n = heights.Count;
            var left = new int[n];
            var right = new int[n];
            for (var i = 1; i < n; ++i)
            {
                left[i] = Math.Max(heights[i - 1], left[i - 1]);
            }

            for (var i = n - 2; i >= 0; --i)
            {
                right[i] = Math.Max(heights[i + 1], right[i + 1]);
            }

            var res = 0;
            for (var i = 0; i < n; ++i)
            {
                res += Math.Max(0, Math.Min(left[i], right[i]) - heights[i]);
            }

            return res;
        }
    }
}