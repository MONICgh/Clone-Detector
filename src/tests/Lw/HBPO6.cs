namespace Application;

public class Bear
{
    private Pot pot;

    public Bear(Pot pot)
    {
        this.pot = pot;
    }

    private void wakeUp()
    {
        Console.WriteLine("Bear wake up");
        Thread.Sleep(200);
        pot.Clear();
        Console.WriteLine("Bear fall asleep");
    }
    
    public void WakeUp()
    {
        Task task = new Task(() => wakeUp());
        task.Start();
        task.Wait();
    }
}
