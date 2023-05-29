
using System;
using System.Collections.Generic;
using System.Linq;

namespace ThreeSum;

public class ThreeSum
{
    public static List<List<int>> Main(List<int> xs)
    {
        var zeroCount = xs.FindAll(it => it == 0).Count;
        for (int i = 0; i < Math.Max(0, 2 - zeroCount); i++)
        {
            xs.Add(0);
        }

        var res = new List<List<int>>();
        for (int i = 0; i < xs.Count; i++)
        {
            for (int j = i + 1; j < xs.Count; j++)
            {
                for (int k = j + 1; k < xs.Count; k++)
                {
                    if (xs[i] + xs[j] + xs[k] == 0)
                    {
                        res.Add(new List<int>{xs[i], xs[j], xs[k]});
                    }
                }
            }
        }

        return res.DistinctBy(it => string.Join(" ", it)).OrderBy(it => it.First()).ToList();
    }
}