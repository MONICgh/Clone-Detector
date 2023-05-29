using System.Collections;
using System.Numerics;

namespace HW_04.LuckyTicket;

class Solver
{
    private struct Pair
    {
        public Pair(int n, int sum)
        {
            _n = n;
            _sum = sum;
        }
        private int _n;
        private int _sum;
    }

    private readonly Dictionary<Pair, BigInteger> _data = new();
    private BigInteger GetWays(int n, int sum)
    {
        if (n == 0)
        {
            return sum == 0 ? 1 : 0;
        }
        if (sum > n * 9)
        {
            return 0;
        }
        var pair = new Pair(n, sum);
        if (_data.ContainsKey(pair))
            return _data[pair];
        BigInteger ways = 0;
        for (var i = 0; i <= Math.Min(sum, 9); i++)
        {
            ways += GetWays(n - 1, sum - i);
        }
        _data[pair] = ways;
        return _data[pair];
    }

    public BigInteger Solve(int n)
    {
        if (n % 2 == 1)
        {
            throw new ArgumentException("Should be multiple of 2");
        }
        var partLen = n / 2;
        BigInteger result = 0;
        for (var i = 0; i <= partLen * 9; i++)
        {
            var ways = GetWays(partLen, i);
            result += ways * ways;
        }
        return result;
    }
}
