IEnumerable<string> translate(string text, Dictionary<string, string> dictionary, int n)
{
    return text.Split()
        .Select(word => word.ToLower())
        .Select(word => dictionary[word].ToUpper())
        .Chunk(n)
        .Select(chunk => string.Join(" ", chunk));
}

var text = "This dog eats too much vegetables after lunch";

var dictionary = new Dictionary<string, string>()
{
    { "after", "после" },
    { "dog", "собака" },
    { "eats", "ест" },
    { "lunch", "обеда" },
    { "much", "много" },
    { "this", "эта" },
    { "too", "слишком" },
    { "vegetables", "овощей" },
};

foreach (var page in translate(text, dictionary, 3))
{
    Console.WriteLine(page);
}