namespace CarManufacturing;

public class Gearbox
{
    public int Gear { get; set; }

    public Gearbox()
    {
        Gear = 1;
    }

    public void FirstGear()
    {   
        Console.WriteLine("Turning first gear on");
        Gear = 1;
    }

    public void SecondGear()
    {   
        Console.WriteLine("Turning second gear on");
        Gear = 2;
    }

    public void ReverseGear()
    {   
        Console.WriteLine("Turning reverse gear on");
        Gear = -1;
    }
}