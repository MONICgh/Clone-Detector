namespace WaterMolecules;

public class H2O
{
    private Barrier barrier = new Barrier(3);
    private Semaphore hydrogen = new Semaphore(2, 2);
    private Mutex oxygen = new Mutex();

    public H2O()
    {
    }

    public void Hydrogen(Action releaseHydrogen)
    {
        hydrogen.WaitOne();
        barrier.SignalAndWait();
        // releaseHydrogen() outputs "H". Do not change or remove this line.
        releaseHydrogen();
        barrier.SignalAndWait();
        hydrogen.Release();
    }

    public void Oxygen(Action releaseOxygen)
    {
        oxygen.WaitOne();
        barrier.SignalAndWait();
        // releaseOxygen() outputs "O". Do not change or remove this line.
        releaseOxygen();
        barrier.SignalAndWait();
        oxygen.ReleaseMutex();
    }
}