using System.Text;

string Rational(int a, int b)
{
    if (a == 0)
    {
        return "0";
    }
    var sb = new StringBuilder();
    sb.Append("0.");
    var map = new Dictionary<int, int>();
    int j;
    for (var i = 2; ; ++i)
    {
        a *= 10;
        if (map.ContainsKey(a))
        {
            j = map[a];
            break;
        }

        map[a] = i;
        sb.Append(a / b);
        a %= b;
    }

    var str = sb.ToString();
    var period = str[j..];
    if (period == "0")
    {
        return str[..j];
    }
    return str[..j] + "(" + period + ")";
}

Console.WriteLine(Rational(2, 5));
Console.WriteLine(Rational(1, 6));
Console.WriteLine(Rational(1, 3));
Console.WriteLine(Rational(1, 7));
Console.WriteLine(Rational(1, 77));