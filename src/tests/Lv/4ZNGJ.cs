var translator = new Dictionary<string, string>
{
    {"this", "эта"},
    {"dog", "собака"},
    {"eats", "ест"},
    {"too", "слишком"},
    {"much", "много"},
    {"vegetables", "овощей"},
    {"after", "после"},
    {"lunch", "обеда"},
};
const string text = "This dog eats too much vegetables after lunch";
const int n = 3;
var book = text.Split(' ').
    Select(word => translator[word.ToLower()].ToUpper()).
    Chunk(n).
    Select(words => string.Join(" ", words)).ToList();
Console.WriteLine(string.Join("\n", book));    