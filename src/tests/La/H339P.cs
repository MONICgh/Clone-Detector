namespace Task3;

public class Enveloper
{
    private readonly int _h;
    private readonly int _w;
    
    public Enveloper(int h, int w)
    {
        _h = h;
        _w = w;
    }
    
    public int Min => Math.Min(_h, _w);

    public int Max => Math.Max(_h, _w);

    public int CompareTo(Enveloper other)
    {
        if (this.Min == other.Min)
        {
            return this.Max - other.Max;
        }

        return this.Min - other.Min;
    }
}