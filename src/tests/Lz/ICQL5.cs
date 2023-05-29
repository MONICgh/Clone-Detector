using System.Linq;

namespace DeckChairs;

public static class DeckChairs
{
    public static int SunLoungers(string str)
    {
        var freeParts = str
            .Replace("01", "11")
            .Replace("10", "11")
            .Split('1');
        return freeParts.Sum(part => (part.Length + 1) / 2);
    }
}