using BlackBoxTask;

var blackbox = new MyBlackBox();
while (true)
{
    var s = Console.ReadLine()!;
    if (s == "End")
    {
        break;
    }

    var parsed = s.Split('(', ')');
    var val = int.Parse(parsed[1]);
    try
    {
        blackbox.DoMethod(parsed[0], val);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
    Console.WriteLine($"Inner Value: {blackbox.GetInnerValue()}");
}