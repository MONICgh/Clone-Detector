using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Transactions;
using System.Xml.Linq;


namespace Application
{
    class Task3
    {
        static int MaxNestedEnvelops(List<Tuple<int, int>> envelopes)
        {
            var envelopesMaxMin = envelopes.Select(x => new Tuple<int, int>(Math.Max(x.Item1, x.Item2), Math.Min(x.Item1, x.Item2))).Distinct().ToList();
            envelopesMaxMin.Sort((x, y) => {
                if (x.Item1 == y.Item1)
                {
                    return x.Item2.CompareTo(y.Item2);
                }
                else
                {
                    return x.Item1.CompareTo(y.Item1);
                }
            });
            var mins = envelopesMaxMin.Select(x => x.Item2).Distinct().ToList();
            int minsCount = mins.Count();
            mins.Sort();
            var dp = new List<Dictionary<int, int>>() { mins.ToDictionary(x => x, _ => 0), mins.ToDictionary(x => x, _ => 0) };
            int dp_i = 0;
            int envelope_i = 0;
            int ind = 0;
            int lastMax = -1;
            while (envelope_i != envelopesMaxMin.Count())
            {
                var envelope = envelopesMaxMin[envelope_i];
                if (envelope.Item1 == lastMax)
                {
                    dp[dp_i][mins[ind]] = dp[1 - dp_i][mins[ind]];
                    while (mins[ind] != envelope.Item2)
                    {
                        if (ind != 0)
                        {
                            dp[dp_i][mins[ind]] = Math.Max(dp[dp_i][mins[ind]], dp[dp_i][mins[ind-1]]);
                        }
                        ind++;
                    }
                    if (ind != 0)
                    {
                        dp[dp_i][mins[ind]] = Math.Max(dp[1 - dp_i][mins[ind - 1]] + 1, dp[dp_i][mins[ind]]);
                        dp[dp_i][mins[ind]] = Math.Max(dp[dp_i][mins[ind - 1]], dp[dp_i][mins[ind]]);
                    }
                    else
                    {
                        dp[dp_i][mins[ind]] = 1;
                    }
                    ind++;
                    envelope_i++;
                }
                else
                {
                    while (ind != minsCount)
                    {
                        dp[dp_i][mins[ind]] = dp[1 - dp_i][mins[ind]];
                        if (ind != 0)
                        {
                            dp[dp_i][mins[ind]] = Math.Max(dp[dp_i][mins[ind]], dp[dp_i][mins[ind - 1]]);
                        }
                        ind++;
                    }
                    ind = 0;
                    dp_i = 1 - dp_i;
                    lastMax = envelope.Item1;
                }
            }
            while (ind != minsCount)
            {
                dp[dp_i][mins[ind]] = dp[1 - dp_i][mins[ind]];
                if (ind != 0)
                {
                    dp[dp_i][mins[ind]] = Math.Max(dp[dp_i][mins[ind]], dp[dp_i][mins[ind - 1]]);
                }
                ind++;
            }
            return dp[dp_i][mins[ind - 1]];
        }

        static void Main()
        {
            var envelopes = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(5, 4),
                new Tuple<int, int>(6, 4),
                new Tuple<int, int>(6, 7),
                new Tuple<int, int>(2, 3),
            };
            var envelopesStr = '[' + String.Join(", ", envelopes) + ']';
            Console.WriteLine($"MaxNestedEnvelops({envelopesStr}) = {MaxNestedEnvelops(envelopes)}");
            envelopes = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(1, 1),
                new Tuple<int, int>(1, 1),
                new Tuple<int, int>(1, 1),
            };
            envelopesStr = '[' + String.Join(", ", envelopes) + ']';
            Console.WriteLine($"MaxNestedEnvelops({envelopesStr}) = {MaxNestedEnvelops(envelopes)}");
        }
    }
}
