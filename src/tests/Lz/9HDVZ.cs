int SunLoungers(string input)
{
    var ans = 0;
    foreach (var s in ("0" + input + "0").Split("1"))
    {
        ans += Math.Max(s.Length - 1, 0) / 2;
    }

    return ans;
}

Console.WriteLine(SunLoungers("000101"));

/*Console.WriteLine(SunLoungers("10001"));
Console.WriteLine(SunLoungers("00101"));
Console.WriteLine(SunLoungers("0"));
Console.WriteLine(SunLoungers("000"));*/
