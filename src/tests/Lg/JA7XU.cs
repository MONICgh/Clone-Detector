namespace H2O;

public class H2O
{
    private readonly Semaphore _semaphoreHydrogen = new Semaphore(2, 2);
    private readonly Semaphore _semaphoreOxygen = new Semaphore(1, 1);
    private readonly Barrier _barrierWater = new Barrier(3);
    
    public void Hydrogen(Action releaseHydrogen) {
        // releaseHydrogen() outputs "H". Do not change or remove this line.
        _semaphoreHydrogen.WaitOne();
        _barrierWater.SignalAndWait();
        releaseHydrogen();
        _barrierWater.SignalAndWait();
        _semaphoreHydrogen.Release();
    }
    public void Oxygen(Action releaseOxygen) {
        // releaseOxygen() outputs "O". Do not change or remove this line.
        _semaphoreOxygen.WaitOne();
        _barrierWater.SignalAndWait();
        releaseOxygen();
        _barrierWater.SignalAndWait();
        _semaphoreOxygen.Release();
    }
} 
