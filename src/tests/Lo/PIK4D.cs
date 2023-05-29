using System.Globalization;

namespace Application
{
    class Task4
    {
        static private object _lock = new object();
        
        static void DoOperaition(List<string> filePathes, List<float> results)
        {
            foreach (var filePath in filePathes)
            {
                var text = File.ReadAllText(filePath).Split();
                var num1 = float.Parse(text[1], CultureInfo.InvariantCulture.NumberFormat);
                var num2 = float.Parse(text[2], CultureInfo.InvariantCulture.NumberFormat);
                switch (text[0])
                {
                    case "1":
                        lock (_lock)
                        {
                            results.Add(num1 + num2);
                        }
                        break;
                    case "2":
                        lock (_lock)
                        {
                            results.Add(num1 * num2);
                        }
                        break;
                    case "3":
                        lock (_lock)
                        {
                            results.Add(num1 * num1 + num2 * num2);
                        }
                        break;
                    default:
                        throw new Exception("wrong operation");
                }
            }
        }
        
        static void AggregateFiles(string directory, string outputFile, int threadsSize)
        {
            var filePathes = Directory.GetFiles(directory);
            var filteredFilePathes = filePathes.ToList().FindAll(x => x.EndsWith(".txt"));
            var results = new List<float>();
            var batchesFilePathes = new List<List<string>>();

            var filesCount = filteredFilePathes.Count;
            var inEachBatch = filesCount / threadsSize;
            var remainder = filesCount % threadsSize;

            int realJ = 0;
            for (int i = 0; i < threadsSize; i++)
            {
                var list = new List<string>();
                for (int j = 0; j < inEachBatch; j++, realJ++) {
                    list.Add(filteredFilePathes[realJ]);
                }

                if (remainder != 0)
                {
                    list.Add(filteredFilePathes[realJ]);
                    remainder--;
                    realJ++;
                }

                if (!list.Any()) break;
                
                batchesFilePathes.Add(list);
            }
            
            var threads = new List<Thread>();
            foreach (var batchFilePathes in batchesFilePathes)
            {
                var thread = new Thread(() => DoOperaition(batchFilePathes, results));
                threads.Add(thread);
                thread.Start();
            }
            foreach (var thread in threads)
            {
                thread.Join();
            }
            var sum = results.Sum();
            File.WriteAllText(outputFile, sum.ToString("e8"));
        }
        
        static void Main()
        {
            var directory = "/Users/andrew/courses/с#/c_sharp/hw14/task4/task4/files";
            var outputFile = "/Users/andrew/courses/с#/c_sharp/hw14/task4/task4/out.dat";
            var threads = 6;
            AggregateFiles(directory, outputFile, threads);
        }
    }
}