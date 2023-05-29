
using System.Xml.Linq;

namespace Application
{
    public class Cache<K, T> : IDisposable where T : IDisposable
    {
        public class Element
        {
            public T Data;
            public DateTimeOffset Time;

            public Element(T data, DateTimeOffset time)
            {
                Data = data;
                Time = time;
            }
        }

        private int? MaxSize;
        private int TL;
        private Thread thWaitForFullGC;
        private bool Exit = false;
        private Dictionary<K, Element> Data = new Dictionary<K, Element>();

        public Cache(int? maxSize = null, int tl = 3000 /*in milliseconds*/)
        {
            MaxSize = maxSize;
            TL = tl;
            thWaitForFullGC = new Thread(new ThreadStart(WaitForFullGCProc));
            thWaitForFullGC.Start();
        }

        public T this[K key]
        {
            get
            {
                Element el = Data[key];
                el.Time = DateTimeOffset.Now;
                Data[key] = el;
                return el.Data;
            }
            set
            {
                DateTimeOffset time = DateTimeOffset.Now;
                int size = Data.Count();
                if (Data.ContainsKey(key))
                {
                    Data[key].Data.Dispose();
                    size--;
                }
                if (size + 1 > MaxSize)
                {
                    Cleaning();
                    if (Data.Count() + 1 > MaxSize)
                    {
                        throw new Exception("cache is full");
                    }
                }
                Data[key] = new Element(value, time);
            }
        }

        public void Add(K key, T value)
        {
            this[key] = value;
        }

        public bool Remove(K key)
        {
            Data[key].Data.Dispose();
            Data.Remove(key);
            return true;
        }

        private void Cleaning()
        {
            var removedKeys = new List<K>();
            DateTimeOffset time = DateTimeOffset.Now;
            foreach (var item in Data)
            {
                if ((time - item.Value.Time).TotalMilliseconds >= TL)
                {
                    removedKeys.Add(item.Key);
                    item.Value.Data.Dispose();
                }
            }
            foreach (K key in removedKeys)
            {
                Data.Remove(key);
            }
        }

        private void WaitForFullGCProc()
        {
            while (true)
            {
                GCNotificationStatus s = GC.WaitForFullGCApproach();
                if (s == GCNotificationStatus.Succeeded)
                {
                    Cleaning();
                }

                Thread.Sleep(500);
                if (Exit)
                {
                    break;
                }
            }
        }

        public void Dispose()
        {
            InternalDispose();
        }

        private void InternalDispose()
        {
            Exit = true;    // it could have been better here, but it will do
            Thread.Sleep(500);
            GC.CancelFullGCNotification();
            foreach (Element el in Data.Values)
            {
                el.Data.Dispose();
            }
        }

        ~Cache()
        {
            InternalDispose();
        }
    }

    public class Disp : IDisposable
    {
        public string Data;
        private byte[] InsideData = new byte[1000];
        public Disp(string data = "")
        {
            Data = data;
        }
        public void Dispose() { }
    }

    public class FileStreamWrapper : IDisposable
    {
        private string Path;
        public FileStream Stream;

        public FileStreamWrapper(string path)
        {
            Path = path;
            Stream = File.Create(path);
        }

        public void Dispose()
        {
            Console.WriteLine($"FileStreamWrapper.Dispose: Path={Path}");
            InternalDispose();
        }

        private void InternalDispose()
        {
            Stream.Close();
        }

        ~FileStreamWrapper()
        {
            InternalDispose();
        }
    }

    class Task1
    {
        static void Example1()
        {
            var cache = new Cache<int, Disp>(3);
            try
            {
                cache.Add(1, new Disp("data"));
                cache.Add(2, new Disp("data2"));
                cache.Add(3, new Disp("data3"));
                cache.Add(4, new Disp("data4"));
            }
            catch (Exception e)
            {
                Console.WriteLine($"Example1: exception: {e}");
            }
            cache.Dispose();
        }

        static void Example2()
        {
            var cache = new Cache<int, Disp>(3);
            cache.Add(1, new Disp("data"));
            cache.Add(2, new Disp("data2"));
            cache.Add(3, new Disp("data3"));
            cache.Add(1, new Disp("data0"));
            Thread.Sleep(3000);
            cache.Add(4, new Disp("data4"));
            cache.Add(5, new Disp("data5"));
            cache.Add(6, new Disp("data6"));
            cache.Dispose();
            Console.WriteLine("Example2");
        }

        static void Example3()
        {
            var cache = new Cache<string, FileStreamWrapper>(3);
            cache.Add("path1", new FileStreamWrapper("path1"));
            cache.Add("path1", new FileStreamWrapper("path0"));
            cache.Add("path1", new FileStreamWrapper("path1"));
            cache.Add("path2", new FileStreamWrapper("path2"));
            cache.Add("path3", new FileStreamWrapper("path3"));
            Thread.Sleep(3000);
            cache["new_path"] = new FileStreamWrapper("new_path");
            cache.Dispose();
            Console.WriteLine("Example3");
        }

        static void Example4()
        {
            var cache = new Cache<string, FileStreamWrapper>(3);
            try
            {
                cache.Add("path1", new FileStreamWrapper("path1"));
                cache.Add("path2", new FileStreamWrapper("path2"));
                Thread.Sleep(2000);
                var fsWrapper1 = cache["path1"];
                var fsWrapper2 = cache["path2"];
                Thread.Sleep(2000);
                cache.Add("path3", new FileStreamWrapper("path3"));
                cache.Add("path4", new FileStreamWrapper("path4"));
                Thread.Sleep(2000);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Example4: exception: {e}");
            }
            cache.Dispose();
        }

        static void Example5()
        {
            Console.WriteLine($"Example5 start");
            var cache = new Cache<long, Disp>();
            long i = 0;
            while (true)
            {
                cache.Add(i, new Disp($"disp_{i}"));
                i++;
            }
            cache.Dispose();
        }

        static void Main()
        {
            Example1();
            Example2();
            Example3();
            Example4();
            Example5();
        }
    }
}
