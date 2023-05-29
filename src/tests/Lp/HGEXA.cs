namespace HomogeneousCache;

public class DisposableItem : IDisposable
{
    private readonly string _name;

    public DisposableItem(string name)
    {
        _name = name;
        Console.WriteLine($"> DisposableItem info: {this} created.");
    }

    public void Dispose()
    {
        Console.WriteLine($"> DisposableItem info: {this} disposed.");
    }

    public override string ToString()
    {
        return "Item(name: '" + _name + "')";
    }
}