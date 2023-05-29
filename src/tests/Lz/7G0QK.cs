namespace Task1;

public class Subscriber : ISubscriber
{
    public int Counter = 0;
    
    public void OnEvent()
    {
        Counter++;
    }
}