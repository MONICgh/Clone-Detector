namespace CarManufacturing;

public interface IBody
{
    public int Number { get; }
    public string Color { get; set; }

    public void Paint(string color);
}

public class Sedan : IBody
{
    public int Number { get; }
    public string Color { get; set; }

    public Sedan(int num)
    {
        Number = num;
        Color = "White";
    }

    public void Paint(string color)
    {
        Color = color;
    }
}

public class Jeep : IBody
{
    public int Number { get; }
    public string Color { get; set; }

    public Jeep(int num)
    {
        Number = num;
        Color = "White";
    }

    public void Paint(string color)
    {
        Color = color;
    }
}