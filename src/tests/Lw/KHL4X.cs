namespace Application;

public class Wolf: Entity
{
    public Wolf(Field field, Tuple<int, int> pos) : base(field, pos)
    {
        field.AddEntity(this);
    }

    protected override void live()
    {
        while (true)
        {
            Thread.Sleep(1000);
            field.move(Dpos());
        }
    }
}
