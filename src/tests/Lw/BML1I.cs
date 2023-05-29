namespace Application;

abstract public class Entity
{
    private static Random rnd = new Random();
    protected Field field;
    protected Tuple<int, int> pos;
    private int width;
    private int height;

    private static List<Tuple<int, int>> moves = new List<Tuple<int, int>>()
    {
        Tuple.Create(1, 1),
        Tuple.Create(1, 0),
        Tuple.Create(1, -1),
        Tuple.Create(0, -1),
        Tuple.Create(-1, -1),
        Tuple.Create(-1, 0),
        Tuple.Create(-1, 1),
        Tuple.Create(0, 1),
    };

    public Entity(Field field, Tuple<int, int> pos)
    {
        this.field = field;
        this.pos = pos;
        width = field.Width;
        height = field.Height;
        var task = new Task(() => live());
        task.Start();
    }

    protected Tuple<int, int> Dpos()
    {
        var possibleMoves = moves.FindAll(dpos =>
        {
            var x = pos.Item1 + dpos.Item1;
            var y = pos.Item2 + dpos.Item2;
            return 0 <= x && x < width && 0 <= y && y < height;
        });
        var moveI = rnd.Next(possibleMoves.Count);
        return possibleMoves[moveI];
    }

    protected virtual void live()
    {
        while (true)
        {
            Thread.Sleep(1000);
        }
    }

    public Tuple<int, int> Pos
    {
        get => pos;
        set => pos = value;
    }
}