string PrimeFactors(int n)
{
    var factors = new List<string>();

    for (var i = 2; i <= n; i++)
    {
        if (n % i != 0)
        {
            continue;
        }

        var cnt = 0;
        while (n % i == 0)
        {
            cnt++;
            n /= i;
        }

        var factor = i.ToString();
        if (cnt > 1)
        {
            factor += "^" + cnt;
        }

        factors.Add(factor);
    }

    return string.Join(" x ", factors);
}

Console.WriteLine(PrimeFactors(2));
Console.WriteLine(PrimeFactors(4));
Console.WriteLine(PrimeFactors(10));
Console.WriteLine(PrimeFactors(60));