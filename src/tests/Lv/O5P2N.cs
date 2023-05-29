namespace MainTasks;

public class Badger : WithName
{
    public Badger(string name)
    {
        Name = name;
    }

    public override bool Equals(object? obj)
    {
        if (obj is (Badger badger))
        {
            return badger.Name == Name;
        } 
        return false;
    }

    public override string Name { get; set; }
}