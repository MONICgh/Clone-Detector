namespace CarFactory.components;

public interface IBody
{
    public int Id { get; }
}

public class CarBody : IBody
{
    public int Id { get; }

    public CarBody(int id)
    {
        Id = id;
    }
}