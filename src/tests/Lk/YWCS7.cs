using System.Diagnostics;

long LuckyTickets(int n)
{
    if (n % 2 != 0)
    {
        return 0;
    }
    
    long[,] d = new long[n/2 + 1, n/2*9 + 1];
    for (int i = 0; i < n / 2 * 9 + 1; i++)
    {
        d[0, i] = 0;
    }

    d[0, 0] = 1;

    for (int i = 1; i <= n / 2; i++)
    {
        for (int j = 0; j <= n / 2 * 9; j++)
        {
            d[i, j] = 0;
            for (int s = j - 9; s <= j; s++)
            {
                if (s < 0)
                    continue;
                d[i, j] += d[i - 1, s];
            }
        }
    }

    long ans = 0;
    for (int i = 0; i <= n / 2 * 9; i++)
    {
        ans += d[n / 2, i] * d[n / 2, i];
    }
    return ans;
}

Debug.Assert(LuckyTickets(2) == 10);
Debug.Assert(LuckyTickets(4) == 670);
Debug.Assert(LuckyTickets(12) == 39581170420);

Console.WriteLine("All is Okay");