namespace BlackBox;

public struct Operation
{
    public string methodName;
    public int argument;

    public Operation(string operation)
    {
        try
        {
            var splitRes = operation.Split('(', ')');
            methodName = splitRes[0];
            argument = Convert.ToInt32(splitRes[1]);
            if (operation != methodName + "(" + argument + ")") throw new IndexOutOfRangeException();
        }
        catch (IndexOutOfRangeException)
        {
            throw new ArgumentException("Invalid operation syntax!");
        }
    }
}