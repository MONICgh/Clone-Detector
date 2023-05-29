using System.Text.RegularExpressions;

IOrderedEnumerable<IGrouping<int, string>> GroupWords(string sentence)
{
    return sentence.ToLower().AsEnumerable()
        .Where(c => new Regex("[a-zA-Zа-яА-ЯёЁ ]").IsMatch("" + c))
        .Aggregate("", (acc, c) => acc + c)
        .Split(" ")
        .Where(w => w.Length > 0)
        .GroupBy(w => w.Length)
        .OrderByDescending(grouping => grouping.Count());
}

void WriteGroupingInfo(IEnumerable<IGrouping<int, string>> data)
{
    foreach (var grouping in data)
    {
        Console.WriteLine("Длина " + grouping.Key + ". Количество " + grouping.Count());
        foreach (var word in grouping)
        {
            Console.WriteLine(word);
        }
        Console.WriteLine();
    }
}

string str = "Это что же получается: ходишь, ходишь в школу, а потом бац - вторая смена";
WriteGroupingInfo(GroupWords(str));