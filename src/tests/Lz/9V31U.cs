namespace HW_05.EventBusImpl;

public class PrinterSubscriber1
{
    public static string GetBeautifulStringWithOutput(int x)
    {
        var beautifulStringWithOutput = "XXX_|" + x + "|_XXX";
        Console.WriteLine(beautifulStringWithOutput);
        return beautifulStringWithOutput;
    }

    public static string GetUglyString(int x)
    {
        var uglyString = "_" + x + "_|||";
        Console.WriteLine(uglyString);
        return uglyString;
    }
}
