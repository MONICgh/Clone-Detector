namespace CarManufacturing;

public class Factory
{
    private readonly Random rng;
    private readonly List<ICar> carProduced;
    public int Count => carProduced.Count;

    public Factory()
    {
        rng = new Random();
        carProduced = new List<ICar>();
    }

    public Ford MakeNewFord()
    {
        var ford = new Ford(rng.Next());
        carProduced.Add(ford);
        return ford;
    }
    
    public Mercedes MakeNewMercedes()
    {
        var mercedes = new Mercedes(rng.Next());
        carProduced.Add(mercedes);
        return mercedes;
    }
    
    public LandRover MakeNewLandRover()
    {
        var landRover = new LandRover(rng.Next());
        carProduced.Add(landRover);
        return landRover;
    }
}