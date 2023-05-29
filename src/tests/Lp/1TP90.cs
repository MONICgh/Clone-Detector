namespace StringPermutations;

public static class PermutationsClass
{
    private static int Factorial(int n)
    {
        return Enumerable.Range(1, n).Aggregate(1, (p, item) => p * item);
    }

    private static List<string> generateAllPermutations(string chars)
    {
        if (chars.Length == 0)
        {
            return new List<string> {""};
        }

        var results = new List<string>(Factorial(chars.Length));
        for (int i = 0; i < chars.Length; i++)
        {
            var newChars = string.Join("", chars.Take(i)) + string.Join("", chars.Skip(i+1));
            generateAllPermutations(newChars).ForEach((it) => results.Add($"{chars[i]}{it}"));
        }

        return results;
    }

    public static string Permutations(string chars)
    {
        var permutations = generateAllPermutations(chars);
        permutations.Sort();
        return string.Join(" ", permutations);
    }
}