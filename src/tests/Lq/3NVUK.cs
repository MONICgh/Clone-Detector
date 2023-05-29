namespace Cars;

public interface IBody
{
    public int ID { get; }
}
    
public class Body : IBody
{
    public int ID { get; }

    public Body()
    {
        ID = IdGenerator.getNextID();
    }
}

public static class IdGenerator
{
    private static int currentID = -1;

    public static int getNextID()
    {
        currentID++;
        return currentID;
    }
}
