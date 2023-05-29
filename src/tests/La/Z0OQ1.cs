// WLOG assume h < w for all envelopes
// Sort envelopes by h. Then we need to find Longest Increasing Subsequence of w's
// That's can be solved in O(n log n)
int Solve((int, int)[] arr)
{
    var map = new Dictionary<int, int>();
    foreach (var (x, y) in arr)
    {
        var (a, b) = (x, y);
        if (a > b)
        {
            (a, b) = (b, a);
        }

        if (!map.ContainsKey(a) || map[a] < b)
        {
            map[a] = b;
        }
    }

    arr = map.ToArray().Select(it => (it.Key, it.Value)).ToArray();
    Array.Sort(arr);

    var n = arr.Length;
    const int inf = (int)1e9;
    var dp = new int [n + 1];
    dp[0] = -inf;
    for (var i = 1; i <= n; ++i) dp[i] = inf;

    foreach (var (h, w) in arr)
    {
        int l = 0, r = n;
        while (l + 1 < r)
        {
            var m = (l + r) / 2;
            if (dp[m] < w)
            {
                l = m;
            }
            else
            {
                r = m;
            }
        }

        dp[l + 1] = w;
    }

    for (var i = n; i >= 1; --i)
    {
        if (dp[i] < inf)
        {
            return i;
        }
    }

    return 0;
}

Console.WriteLine(Solve(new (int, int)[] {(5, 4), (6, 4), (6, 7), (2, 3)}));
Console.WriteLine(Solve(new (int, int)[] {(1, 1), (1, 1), (1, 1)}));