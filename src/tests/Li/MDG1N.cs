string stringyFib(int n)
{
    if (n < 2)
        return "invalid";

    var result = new List<string>();
    
    var f = "b";
    var s = "a";
    result.Add(f);
    result.Add(s);
    
    for (var i = 2; i < n; i++)
    {
        var tmp = s + f;
        f = s;
        s = tmp;
        result.Add(s);
    }

    return string.Join(", ", result);
}

Console.WriteLine(stringyFib(1));
Console.WriteLine(stringyFib(3));
Console.WriteLine(stringyFib(7));