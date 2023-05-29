namespace HW_15.WolfAndSheeps;

class Entity
{
    private int x, y;
    public bool isDead = false;
    public Entity(int n)
    {
        Random r = new Random();
        x = r.Next() % n;
        y = r.Next() % n;
    }
    public void Move(Coordinates coordinates)
    {
        x += coordinates.x;
        y += coordinates.y;
    }

    public bool CoordEqual(Entity other)
    {
        return x == other.x && y == other.y;
    }
}

class Coordinates
{
    public int x;
    public int y;
    public Coordinates(int y, int x)
    {
        this.y = y;
        this.x = x;
    }


    public static List<Coordinates> GetMoves()
    {
        return new List<Coordinates>
        {
            new(-1, -1),
            new(-1, 0),
            new(-1, 1),
            new(0, -1),
            new(0, 1),
            new(1, -1),
            new(1, 0),
            new(1, 1),
        };
    }
}

public class SimulationWolvesNSheeps
{
    private int N;
    private readonly object dataLock = new();
    public SimulationWolvesNSheeps(int n)
    {
        N = n;
        _sheeps = new List<Entity> { new(N), new(N), new(N) };
        _wolf = new Entity(N);
    }

    private readonly Entity _wolf;
    private List<Entity> _sheeps;

    void Move(Entity entity)
    {
        var rand = new Random();
        while (true)
        {
            Thread.Sleep(rand.Next() % 100 + 50);
            lock (dataLock)
            {
                if (entity.isDead)
                    return;
                if (_sheeps.Count == 0)
                    return;
                var move = Coordinates.GetMoves()[new Random().Next() % 8];
                entity.Move(move);
                CheckCollisions();
            }
        }
    }
    private void CheckCollisions()
    {
        foreach (var entity in _sheeps.Where(it => it.CoordEqual(_wolf)))
        {
            entity.isDead = true;
        }
        _sheeps = _sheeps.Where(it => !it.CoordEqual(_wolf)).ToList();
    }

    public void Run()
    {
        var task = Task.Run(() => Move(_wolf));
        foreach (var t in _sheeps)
        {
            Task.Run(() => Move(t));
        }
        task.Wait();

    }
}
