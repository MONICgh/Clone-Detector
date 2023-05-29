namespace PasswordGenerator;

public class PasswordGenerator
{
    const int MaxLen = 20;
    const int MinLen = 6;

    private static readonly List<char> Digits = "0123456789".ToList();
    private static readonly List<char> UpperChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToList();
    private static readonly List<char> LowerChars = "abcdefghijklmnopqrstuvwxyz".ToList();

    private static List<char> GenerateChars(int count, List<char> dataset)
    {
        var random = new Random();
        var result = new List<char>();

        for (int i = 0; i < count; i++)
        {
            result.Add(dataset[random.Next(0, dataset.Count)]);
        }

        return result;
    }

    private static bool CheckNeighborDigits(List<char> password)
    {
        for (int i = 0; i < password.Count - 1; i++)
        {
            if (Digits.Contains(password[i]) && Digits.Contains(password[i + 1]))
            {
                return false;
            }
        }

        return true;
    }

    private static List<char> Suffle(List<char> str)
    {
        var random = new Random();
        return str.OrderBy(_ => random.Next()).ToList();
    }

    public static string Generate()
    {
        var random = new Random();
        
        var symbols = new List<char> { '_' };

        var upperCount = random.Next(2, MaxLen - symbols.Count);
        var upperChars = GenerateChars(upperCount, UpperChars);
        symbols.AddRange(upperChars);

        var digitCount = random.Next(Math.Min(5, MaxLen - symbols.Count));
        var digitChars = GenerateChars(digitCount, Digits);
        symbols.AddRange(digitChars);

        var lowerCount = random.Next(Math.Min(MinLen, MaxLen - symbols.Count), MaxLen - symbols.Count);
        var lowerChars = GenerateChars(lowerCount, LowerChars);
        symbols.AddRange(lowerChars);

        var password = Suffle(symbols);
        while (!CheckNeighborDigits(password))
        {
            password = Suffle(password);
        }
        
        return string.Join("", password);
    }
}