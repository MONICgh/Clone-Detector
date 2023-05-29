using System; 
using System.Collections.Generic;

namespace task1
{
    class Cache<T> where T : class, IDisposable
    {
        private int _maxSize;
        private TimeSpan _maxTimeout;
        private volatile bool _GCNotificatonReceived = false;

        private Dictionary<string, T> _cache;
        private Dictionary<string, DateTime> _timestamps;


        private bool CheckOverflow => Size + 1 > _maxSize;
        private void WaitingGC() => new Thread(CheckGСNotification).Start();

        public int Size => _cache.Count;

        public Cache(TimeSpan maxTimeout, int maxSize = 100)
        {
            _maxSize = maxSize;
            _maxTimeout = maxTimeout;
            _cache = new Dictionary<string, T>();
            _timestamps = new Dictionary<string, DateTime>();

            GC.RegisterForFullGCNotification(5, 5);
            WaitingGC();
        }

        ~Cache()
        {
            Clear();
        }


        public void Add(string id, T element)
        {
            if (CheckOverflow || _GCNotificatonReceived)
            {
                Clear();
                if (CheckOverflow)
                {
                    Console.WriteLine("No space left in cache");
                    return;
                }
            }

            if (!_cache.ContainsKey(id))
            {
                _cache.Add(id, element);
                _timestamps.Add(id, DateTime.Now);
            }

        }

        public T? Get(string id)
        {
            if (_GCNotificatonReceived)
                Clear();

            if (_cache.ContainsKey(id))
            {
                _timestamps[id] = DateTime.Now;
                return _cache[id];
            }

            return null;
        }

        private void Clear()
        {
            foreach (var (id, timestamp) in _timestamps)
            {
                var delta = DateTime.Now - timestamp;
                if (delta > _maxTimeout)
                {
                    _cache[id].Dispose();
                    _cache.Remove(id);
                    _timestamps.Remove(id);
                }
            }

            if (_GCNotificatonReceived)
            {
                Console.WriteLine("Garbage collector called");
                _GCNotificatonReceived = false;
                WaitingGC();
            }
        }

        public void getItems()
        {
            if (_GCNotificatonReceived)
            {
                Clear();
            }
            foreach (string id in _cache.Keys)
            {
                Console.WriteLine($"{id}: {_cache[id]}");
            }
        }

        

        private void CheckGСNotification()
        {
            while (true)
            {
                if (GC.WaitForFullGCApproach() == GCNotificationStatus.Succeeded)
                {
                    _GCNotificatonReceived = true;
                    break;
                }
            }
        }

    }
}
   