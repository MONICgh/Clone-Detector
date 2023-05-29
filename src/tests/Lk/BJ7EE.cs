long LuckyTicketsCounter(int len)
{
    if (len % 2 != 0)
    {
        return 0;
    }

    var maxSum = (len / 2) * 9;
    var sumsCount = new long[len / 2 + 1, maxSum + 1];

    sumsCount[0, 0] = 1L;
    for (var curLen = 1; curLen <= len / 2; curLen++)
    {
        for (var curSum = 0; curSum <= maxSum; curSum++)
        {
            for (var k = 0; k <= Math.Min(curSum, 9); k++)
            {
                sumsCount[curLen, curSum] += sumsCount[curLen - 1, curSum - k];
            }
        }
    }

    var luckyTicketsCount = 0L;
    for (var curSum = 0; curSum <= maxSum; curSum++)
    {
        luckyTicketsCount += sumsCount[len / 2, curSum] * sumsCount[len / 2, curSum];
    }

    return luckyTicketsCount;
}


Console.WriteLine("LuckyTicketsCounter(2) = " + LuckyTicketsCounter(2));
Console.WriteLine("LuckyTicketsCounter(4) = " + LuckyTicketsCounter(4));
Console.WriteLine("LuckyTicketsCounter(12) = " + LuckyTicketsCounter(12));