namespace SleepingBarber;

public record Client(int id, int processingTime)
{
    public override string ToString()
    {
        return "Client " + id;
    }
}