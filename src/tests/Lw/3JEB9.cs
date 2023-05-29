namespace Task3;

public class Client
{
    private int _number;
    private bool _cuted = false; 
    public Client(int number)
    {
        _number = number;
        Console.WriteLine("Клиент #" + _number + " пришёл");
    }
    
    public void Cut()
    {
        Console.WriteLine("Клиент #" + _number + " подстригся");
        _cuted = true;
    }

    public void Leave()
    {
        if (_cuted)
        {
            Console.WriteLine("Клиент #" + _number + " ушёл, подстригшись");
        }
        else
        {
            Console.WriteLine("Клиент #" + _number + " ушёл, не подстригшись");
        }
    }
}