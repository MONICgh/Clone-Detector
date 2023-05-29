namespace Application;

public class Bee
{
    private static Random rnd = new Random();
    private Bear bear;
    private Pot pot;
    private int id;
    
    public Bee(Pot pot, int id, Bear bear)
    {
        this.pot = pot;
        this.id = id;
        this.bear = bear;
    }

    private void work()
    {
        while (true)
        {
            Console.WriteLine($"Bee {id} start collecting honey");
            Thread.Sleep(rnd.Next(1, 2_000));
            Console.WriteLine($"Bee {id} collected honey");
            var potIsFull = pot.AddHoney();
            Console.WriteLine($"Bee {id} added honey");
            if (potIsFull)
            {
                Console.WriteLine($"Bee {id} woke up the bear");
                bear.WakeUp();
            }
        }
    }
    
    public void Work()
    {
        Task task = new Task(() => work());
        task.Start();
    }
}
