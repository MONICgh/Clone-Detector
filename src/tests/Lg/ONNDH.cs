namespace H2O;

public class H2O
{
    private readonly object _locker = new();
    private readonly Barrier _barrier = new(3);
    private readonly Semaphore _hydrogen = new(2, 2);
    private readonly Semaphore _oxygen = new(1, 1);

    public void Hydrogen(Action releaseHydrogen)
    {
        Release(_hydrogen, releaseHydrogen);
    }

    public void Oxygen(Action releaseOxygen)
    {
        Release(_oxygen, releaseOxygen);
    }

    private void Release(Semaphore molecule, Action releaseMolecule)
    {
        molecule.WaitOne();
        _barrier.SignalAndWait();
        
        lock (_locker)
        {
            releaseMolecule();
        }

        _barrier.SignalAndWait();
        molecule.Release();
    }
}