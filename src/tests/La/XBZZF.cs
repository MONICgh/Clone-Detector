using System.Collections;
using System.ComponentModel;

namespace HW_10;

public class Envelop
{
    private int _x;
    private int _y;

    public Envelop(int x, int y)
    {
        _x = x;
        _y = y;
    }

    public bool IsWellOriented()
    {
        return _x < _y;
    }

    public void Rotate()
    {
        (_x, _y) = (_y, _x);
    }

    public bool Smaller(Envelop other)
    {
        return _x < other._x && _y < other._y;
    }
}

public static class EnvelopSolver
{
    public static int Solve(IReadOnlyList<Envelop> envelops)
    {
        var ways = new List<List<int>>();
        for (var i = 0; i < envelops.Count; i++)
        {
            ways.Add(new List<int>());
            for (var j = 0; j < envelops.Count; j++)
            {
                if (envelops[i].Smaller(envelops[j]))
                    ways[i].Add(j);
            }
        }

        var cached = new Dictionary<int, int>();
        for (int i = 0; i < ways.Count; i++)
        {
            CalcResults(i, ways, cached);
        }
        return cached.Select(v => v.Value).Max();
    }

    private static void CalcResults(int current, IReadOnlyList<List<int>> ways, IDictionary<int, int> cache)
    {
        if (cache.ContainsKey(current))
        {
            return;
        }
        cache.Add(current, 1);
        for (var i1 = 0; i1 < ways[current].Count; i1++)
        {
            int next = ways[current][i1];
            CalcResults(next, ways, cache);

            var value = cache[current];
            value = Math.Max(cache[next] + 1, value);
            cache[current] = value;
        }

    }


}
