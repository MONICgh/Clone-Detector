namespace Task2;

public class Board
{
    public int N;
    public Dictionary<long, Sheep> Sheeps = new Dictionary<long, Sheep>();
    public Wolf Wolf;
    public int NumberSheeps = 0;
    public object Locker = new object();
    
    public Board(int n)
    {
        N = n;
    }

    public void Start()
    {
        var random = new Random();
        Wolf = new Wolf(random.Next(N), random.Next(N), this);
        for (int i = 0; i < 3; i++) 
            SheepBirth(random.Next(N), random.Next(N));
        while (Sheeps.Count > 0) {}
    }

    public void SheepBirth(int x, int y)
    {
        NumberSheeps++;
        Sheeps.Add(NumberSheeps, new Sheep(NumberSheeps, x, y, this));
    }

    public void WolfEats(int sheepId)
    {
        Sheeps[sheepId].Die();
        Sheeps.Remove(sheepId);
    }
}