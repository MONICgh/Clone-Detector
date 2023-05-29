namespace Application;

public class Hairdresser
{
    public enum State
    {
        CUT, 
        SLEEP,
        WAIT,
    }

    private State state;

    public Hairdresser()
    {
        state = State.SLEEP;
    }
    
    public void cut(string name)
    {
        if (state == State.SLEEP)
        {
            Console.WriteLine("Hairdresser wake up");
            Thread.Sleep(100);
        }
        Console.WriteLine($"Hairdresser start cuts {name}");
        state = State.CUT;
        Thread.Sleep(300);
        Console.WriteLine($"Hairdresser finish cuts {name}");
        state = State.WAIT;
    }
    
    public void sleep()
    {
        if (state != State.SLEEP)
        {
            state = State.SLEEP;
            Console.WriteLine("Hairdresser sleep");
        }   
    }

    public Hairdresser.State HairdresserState
    {
        get => state;
    }
}
