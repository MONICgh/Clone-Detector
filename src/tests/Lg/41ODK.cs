
namespace task3
{
    class H2O
    {
        private readonly object  _hLock = new object();
        private readonly object _oLock = new object();
        private int _hydrogenAtoms = 0;
        private readonly Barrier _barrier = new Barrier(2);


        public void Hydrogen(Action releaseHydrogen)
        {
            lock (_hLock)
            {
                ++_hydrogenAtoms;

                releaseHydrogen();

                if (_hydrogenAtoms == 2)
                {
                    _barrier.SignalAndWait();
                    _hydrogenAtoms = 0;
                }
            }
        }

        public void Oxygen(Action releaseOxygen)
        {
            lock (_oLock)
            {
                releaseOxygen();
                _barrier.SignalAndWait();
            }
        }
    }
}

