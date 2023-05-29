using System;
using System.Collections.Generic;
using System.Text;

using CSdotnet;

namespace CSDotNet.Lab2
{
    public class RainWater
    {
        public int collectRainWater(int[] bars)
        {
            int sum = 0;
            StackMinValue<int> stack = new StackMinValue<int>();
            for (int i = 0; i < bars.Length; ++i)
            {
                while (stack.Count > 0 && bars[stack.Top] < bars[i])
                {
                    // Calculate water
                    int pop_height = stack.Pop();
                    if (stack.Count == 0)
                        break;

                    int dist = i - stack.Top - 1;
                    sum += dist * (Math.Min(bars[(int)stack.Top], bars[i]) - pop_height);
                }

                stack.Push(i);
            }

            return sum;
        }
    }
}
