IEnumerable<string> bucketize(string text, int n)
{
    var buckets = new List<string>();
    foreach (var word in text.Split())
    {
        if (word.Length == 0) continue;
        if (buckets.Count > 0 && buckets.Last().Length + 1 + word.Length <= n)
        {
            buckets[^1] += " " + word;
        }
        else if (word.Length <= n)
        {
            buckets.Add(word);
        }
        else
        {
            return new List<string>();
        }
    }

    return buckets.Select(bucket => $"\"{bucket}\"");
}

Console.WriteLine("[" + string.Join(", ", bucketize("она продает морские раковины у моря", 16)) + "]");
Console.WriteLine("[" + string.Join(", ", bucketize("мышь прыгнула через сыр", 8)) + "]");
Console.WriteLine("[" + string.Join(", ", bucketize("волшебная пыль покрыла воздух", 15)) + "]");
Console.WriteLine("[" + string.Join(", ", bucketize("a b  c d e  ", 2)) + "]");
Console.WriteLine("[" + string.Join(", ", bucketize("мышь прыгнула через сыр", 2)) + "]");