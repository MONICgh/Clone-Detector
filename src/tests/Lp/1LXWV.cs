namespace Cache
{
    public class Cache<T> where T : IDisposable
    {
        private readonly int maxSize;
        private readonly double timeExpiredInSec;
        private List<(T, DateTime)> cache;
        private bool gcNotify;
        public Cache(int _maxSize, double _timeExpired, bool garbageNotifications)
        {
            maxSize = _maxSize;
            timeExpiredInSec = _timeExpired;
            cache = new List<(T, DateTime)>();
            gcNotify = false;

            if (garbageNotifications)
            {
                GC.RegisterForFullGCNotification(1, 1);
                new Thread(checkGCStatus).Start();
            }
        }

        private void checkGCStatus()
        {
            while (true)
            {
                if (GC.WaitForFullGCApproach() == GCNotificationStatus.Succeeded)
                {
                    Console.WriteLine("Catch notify");
                    gcNotify = true;
                    break;
                }
            }
        }

        private void Clear()
        {
            DateTime now = DateTime.Now;
            List<(T, DateTime)> alive = new();
            foreach (var (inner_elem, time) in cache)
            {
                if (now.Subtract(time).TotalSeconds <= timeExpiredInSec)
                {
                    alive.Add((inner_elem, time));
                }
                else
                {
                    inner_elem.Dispose();
                }
            }
            cache = alive;
        }

        public void Add(T elem)
        {
            if (cache.Count == maxSize || gcNotify)
            {
                Clear();
            }
            if (cache.Count != maxSize)
            {
                cache.Add((elem, DateTime.Now));
            }
        }

        public T Get(int index)
        {
            if (gcNotify)
            {
                Clear();
            }

            cache[index] = (cache[index].Item1, DateTime.Now);
            return cache[index].Item1;
        }
    }
}