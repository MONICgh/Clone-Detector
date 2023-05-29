namespace Application;

public class H2OGenerator
{
    private void releaseHydrogen()
    {
        Console.Write("H");
    }
        
    private void releaseOxygen()
    {
        Console.Write("O");
    }
    
    public void Generate(string molecules)
    {
        var threads = new List<Thread>();
        var h2O = new H2O();
        
        foreach (var molecule in molecules)
        {
            if (molecule == 'H')
            {
                threads.Add(new Thread(() => h2O.Hydrogen(releaseHydrogen)));
            }
            else if (molecule == 'O')
            {
                threads.Add(new Thread(() => h2O.Oxygen(releaseOxygen)));
            }
            else
            {
                throw new Exception("wrong molecule");
            }
        }
        
        foreach (var thread in threads)
        {
            thread.Start();
        }
            
        foreach (var thread in threads)
        {
            thread.Join();
        }
    }
}
