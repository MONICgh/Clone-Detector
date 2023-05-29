using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Lab11
{
    public class DisposeObject : IDisposable
    {
        public IDisposable obj;
        public long Timestamp { get; private set; }

        public IDisposable Get() // because obj is not a property
        {
            return obj;
        }

        public bool IsOld(long disposeInterval)
        {
            return (DateTime.Now.Ticks - Timestamp) > disposeInterval;
        }

        public DisposeObject(IDisposable obj)
        {
            this.obj = obj;
            Timestamp = DateTime.Now.Ticks;
        }
        
        public void Dispose()
        {
            obj?.Dispose();
        }
    }

    public class DisposeCache
    {
        public DisposeObject[] objects;
        long disposeInterval; // in milliseconds

        public DisposeCache(int size, int dispose_interval_milliseconds)
        {
            objects = new DisposeObject[size];
            disposeInterval = dispose_interval_milliseconds * 10000;
        }
        public DisposeCache(int size) : this(size, 2000) { }

        private int HasSpace()
        {
            for (int i = 0; i < objects.Length; ++i)
                if (objects[i] == null)
                    return i;
            return -1;
        }

        public void Add(IDisposable obj)
        {
            int i = HasSpace();
            while (i == -1)
            {
                Dispose(null, null);
                i = HasSpace();
                //if (!HasSpace())
                //    throw new Exception("Cache is full!");
            }
            objects[i] = new DisposeObject(obj);
        }

        public void RegisterForFullGCNotification(Action<EventHandler> attach)
        {
            attach(Dispose);
        }

        private void Dispose(object o, EventArgs e)
        {
            Console.WriteLine("kek!");
            for (int i = 0; i < objects.Length; ++i)
            {
                if (objects[i] == null)
                    continue;
                if (objects[i].IsOld(disposeInterval))
                {
                    objects[i].Dispose();
                    objects[i] = null;
                    continue;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder strb = new StringBuilder();
            foreach (var obj in objects)
            {
                if (obj == null)
                    continue;
                strb.AppendLine(obj.Get().ToString());
            }
            return strb.ToString();
        }
    }
}
