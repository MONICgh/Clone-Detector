namespace Cars;

public interface IDashBoard
{
    public int CountOfDisplays { get; }
}

public class DashBoard : IDashBoard
{
    public DashBoard(int countOfDisplays)
    {
        CountOfDisplays = countOfDisplays;
    }

    public int CountOfDisplays { get; }
}