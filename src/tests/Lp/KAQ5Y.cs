namespace Cache;

public class DisposableItem : IDisposable
{
    private readonly string name;

    public DisposableItem(string name)
    {
        this.name = name;
    }

    public void Dispose()
    {
        Console.WriteLine($"Disposed of {name}");
    }
}
