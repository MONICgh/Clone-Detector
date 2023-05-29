namespace Task1.model.body;

public class AbstractBody
{
    private int _number;

    protected AbstractBody(int number)
    {
        _number = number;
    }

    public override string ToString()
    {
        return "Body: number = " + _number;
    }
}