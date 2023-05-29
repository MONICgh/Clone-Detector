using System.Diagnostics;

int CharType(char a)
{
    if (char.IsUpper(a))
    {
        return 1;
    }

    if (char.IsLower(a))
    {
        return 0;
    }

    if (char.IsDigit(a))
    {
        return 2;
    }

    return 3;
}

int CharComparator(char a, char b)
{
    var aType = CharType(a);
    var bType = CharType(b);
    if (aType != bType && (aType == 2 || bType == 2))
    {
        return aType - bType;
    }

    if (Char.ToLower(a) == Char.ToLower(b))
    {
        return aType - bType;
    }

    return Char.ToLower(a) - Char.ToLower(b);
}

string sorting(string s)
{
    var list = s.ToList();
    list.Sort(CharComparator);
    return string.Join("", list);
}

Debug.Assert(sorting("eA2a1E").Equals("aAeE12"));
Debug.Assert(sorting("Re4r").Equals("erR4"));
Debug.Assert(sorting("6jnM31Q").Equals("jMnQ136"));
Debug.Assert(sorting("846ZIbo").Equals("bIoZ468"));

Console.WriteLine("All is Okay!");