IEnumerable<string> Bucketize(string text, int n)
{
    var words = text.Split(' ');
    if (words.MaxBy(word => word.Length)!.Length > n)
    {
        return new List<string>();
    }
    return words.Skip(1).Aggregate(words.Take(1).ToList(), (a, w) =>
    {
        var last = a.Last();
        while (last.Length > n)
        {
            a[^1] = last[..n];
            last = last[n..];
            a.Add(last);
        }

        var test = last + " " + w;
        if (test.Length > n)
        {
            a.Add(w);
        }
        else
        {
            a[^1] = test;
        }

        return a;
    });
}

var res = Bucketize("она продает морские раковины у моря", 16);
foreach (var line in res)
{
    Console.WriteLine(line);
}
Console.WriteLine();

res = Bucketize("мышь прыгнула через сыр", 8);
foreach (var line in res)
{
    Console.WriteLine(line);
}
Console.WriteLine();

res = Bucketize("волшебная пыль покрыла воздух", 15);
foreach (var line in res)
{
    Console.WriteLine(line);
}
Console.WriteLine();

res = Bucketize("a b c d e ", 2);
foreach (var line in res)
{
    Console.WriteLine(line);
}
Console.WriteLine();