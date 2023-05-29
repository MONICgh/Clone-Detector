namespace Application;

public class Ram: Entity
{
    private bool isLive = true;

    public Ram(Field field, Tuple<int, int> pos) : base(field, pos)
    {
        field.AddEntity(this);
    }
    
    protected override void live()
    {
        while (isLive)
        {
            Thread.Sleep(1000);
            if (!isLive) continue;
            field.move(this, Dpos());
        }
    }

    public void Die()
    {
        isLive = false;
    }
}
