namespace Application;

public class Field
{
    private Dictionary<Tuple<int, int>, List<Ram>> rams;
    private int height;
    private int width;
    private Wolf wolf;
    private readonly object _lock = new object();

    public Field(int width, int height)
    {
        this.width = width;
        this.height = height;
        rams = new Dictionary<Tuple<int, int>, List<Ram>>();
    }

    public void AddEntity(Wolf wolf)
    {
        if (this.wolf != null) throw new Exception("wolf already exist");
        this.wolf = wolf;
        move(Tuple.Create(0, 0));   // kill all from his cell
    }
    
    public void AddEntity(Ram ram)
    {
        lock (_lock)
        {
            if (!rams.TryGetValue(ram.Pos, out List<Ram> posRams))
            {
                posRams = new List<Ram>();
                rams[ram.Pos] = posRams;
            }
            posRams.Add(ram);
        }
    }
    
    public void move(Tuple<int, int> dpos)  // for wolf
    {
        lock (_lock)
        {
            wolf.Pos = Tuple.Create(wolf.Pos.Item1 + dpos.Item1, wolf.Pos.Item2 + dpos.Item2);

            if (rams.ContainsKey(wolf.Pos))
            {
                foreach (var ram in rams[wolf.Pos])
                {
                    ram.Die();
                }

                rams.Remove(wolf.Pos);
            }
        }
    }

    public void move(Ram ram, Tuple<int, int> dpos)
    {
        lock (_lock)
        {
            rams[ram.Pos].Remove(ram);
            if (rams[ram.Pos].Count == 0)
            {
                rams.Remove(ram.Pos);
            }
            
            ram.Pos = Tuple.Create(ram.Pos.Item1 + dpos.Item1, ram.Pos.Item2 + dpos.Item2);
            if (wolf.Pos.Equals(ram.Pos))
            {
                ram.Die();
                return;
            }
            
            if (!rams.TryGetValue(ram.Pos, out List<Ram>? posRams))
            {
                posRams = new List<Ram>();
                rams[ram.Pos] = posRams;
            }
            
            posRams.Add(ram);
            if (posRams.Count > 1)
            {
                posRams.Add(new Ram(this, ram.Pos));
            }
        }
    }

    public string Show()
    {
        var field = new List<List<Char>>();
        
        for (int i = 0; i < height; i++)
        {
            field.Add(new String('.', width).ToList());
        }

        lock (_lock)
        {
            foreach (var (pos, list) in rams)
            {
                if (list.Count == 0)
                {
                    throw new Exception("empty list in show");
                }
                field[pos.Item1][pos.Item2] = 'R';
            }

            if (field[wolf.Pos.Item1][wolf.Pos.Item2] == 'R')
            {
                throw new Exception("R shold not be there");
            }
            field[wolf.Pos.Item1][wolf.Pos.Item2] = 'W';
        }

        return String.Join("\n", field.Select(x => String.Concat(x)));
    }
    
    public int Width
    {
        get => width;
    }
    
    public int Height
    {
        get => height;
    }
}
