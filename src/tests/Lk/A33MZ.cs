namespace HW_04.InterfacesAndClasses;

internal interface IPrintable
{
    public string ToPrintableStr(string data);
}

internal interface IOutput
{
    public string ToPrintableStr(string data);
}

public abstract class AbstractPrintable
{
    public abstract string ToPrintableStr(string data);
}

public class PrintController : AbstractPrintable, IPrintable, IOutput
{

    public override string ToPrintableStr(string data)
    {
        return data + " abstract";
    }

    string IPrintable.ToPrintableStr(string data)
    {
        return data + " IPrintable";
    }

    string IOutput.ToPrintableStr(string data)
    {
        return data + " IOutput";
    }
}
