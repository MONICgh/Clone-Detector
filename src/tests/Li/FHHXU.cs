int Compare(char c1, char c2)
{
    if (char.IsLetter(c1) && char.IsDigit(c2)) return -1;
    if (char.IsDigit(c1) && char.IsLetter(c2)) return 1;
    if (char.IsDigit(c1) && char.IsDigit(c2)) return c1.CompareTo(c2);
    if (char.ToLower(c1) == char.ToLower(c2))
    {
        if ((char.IsUpper(c1) && char.IsUpper(c2)) || (char.IsLower(c1) && char.IsLower(c2))) return c1.CompareTo(c2);
        if (char.IsLower(c1)) return -1;
        if (char.IsLower(c2)) return 1;
    }

    return char.ToLower(c1).CompareTo(char.ToLower(c2));
}

string Sorting(string s)
{
    var chars = s.ToList();
    chars.Sort(Compare);
    return string.Join("", chars);
}

Console.WriteLine(Sorting("eA2a1E"));
Console.WriteLine(Sorting("Re4r"));
Console.WriteLine(Sorting("6jnM31Q"));
Console.WriteLine(Sorting("846ZIbo"));
