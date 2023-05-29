namespace Application;

public class H2O
{
    private static int hNeed = 2;
    private static int oNeed = 1;
    private Semaphore hSemaphore = new Semaphore(hNeed, hNeed);
    private Semaphore oSemaphore = new Semaphore(oNeed, oNeed);
    static Barrier barrier = new Barrier(participantCount: hNeed + oNeed);
    
    public H2O()
    {
    }
    
    public void Hydrogen(Action releaseHydrogen)
    {
        hSemaphore.WaitOne();
        // releaseHydrogen() outputs "H". Do not change or remove this line.
        releaseHydrogen();
        barrier.SignalAndWait();
        hSemaphore.Release();
    }
    
    public void Oxygen(Action releaseOxygen) 
    {
        oSemaphore.WaitOne();
        // releaseOxygen() outputs "O". Do not change or remove this line.
        releaseOxygen();
        barrier.SignalAndWait();
        oSemaphore.Release();
    }
}
