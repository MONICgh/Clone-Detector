using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Collections.Generic;

namespace Lab14
{
    public static class FileCalculator
    {
        public static float CalculateFile(string path)
        {
            try
            {
                using (StreamReader fs = File.OpenText(path))
                {
                    int a = Int32.Parse(fs.ReadLine());
                    var args = fs.ReadLine().Split(" ").Select(s => float.Parse(s)).ToList();

                    switch (a)
                    {
                        case 1:
                            return args[0] + args[1];
                        case 2:
                            return args[0] * args[1];
                        case 3:
                            return (args[0] * args[0]) + (args[1] * args[1]);
                        default:
                            throw new Exception();
                    }
                }
            }
            catch
            {
                return 0;
            }
        }

        public static float CalculateThreaded(int threadNum, string sourceDirectory)
        {
            var txtFiles = Directory.EnumerateFiles(sourceDirectory, "*.txt");
            var filelist = txtFiles.ToList();
            int chunkSize = (int)Math.Ceiling((float)(filelist.Count) / threadNum);
            var fileChunks = filelist.Select((x, i) => new { Index = i, Value = x })
            .GroupBy(x => x.Index / chunkSize)
            .Select(x => x.Select(v => v.Value).ToList())
            .ToList();
            float sum = 0;

            Mutex mutex = new Mutex();

            List<Thread> threads = new List<Thread>();
            for(int i = 0; i < threadNum; ++i)
            {
                threads.Add(new Thread(new ParameterizedThreadStart(CalculateFiles)));
            }

            for (int i = 0; i < threadNum; ++i)
            {
                threads[i].Start(fileChunks[i]);
            }

            for (int i = 0; i < threadNum; ++i)
            {
                threads[i].Join();
            }

            return sum;

            void CalculateFiles(object obj)
            {
                var paths = (List<string>)obj;
                float result = 0;
                foreach (var path in paths)
                    result += CalculateFile(path);
                mutex.WaitOne();
                sum += result;
                mutex.ReleaseMutex();
            }
        }
    }
}
