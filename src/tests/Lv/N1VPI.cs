using System.Text.RegularExpressions;

IEnumerable<string> GoodVisibleTranslate(string text, Dictionary<string, string> dictionary, int n)
{
    return text.ToLower().AsEnumerable()
        .Where(c => new Regex("[a-zA-Zа-яА-ЯёЁ ]").IsMatch("" + c))
        .Aggregate("", (acc, c) => acc + c)
        .Split(" ")
        .Select(word => dictionary[word])
        .Chunk(n)
        .Select(list => list.Aggregate((acc, word) => acc + " " + word).ToUpper());
}

var dict = new Dictionary<string, string>
{
    { "this", "эта" },
    { "dog", "собака" },
    { "eats", "ест" },
    { "too", "слишком" },
    { "much", "много" },
    { "vegetables", "овощей" },
    { "after", "после" },
    { "lunch", "обеда" }
};

var text = "This dog eats too much vegetables after lunch.";

foreach (var page in GoodVisibleTranslate(text, dict, 3))
{
    Console.WriteLine(page);
}