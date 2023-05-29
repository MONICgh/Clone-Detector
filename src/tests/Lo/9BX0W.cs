using System.Collections.Concurrent;

namespace Task4;

public class Calculator
{
    private readonly ConcurrentQueue<string> _fileNames = new ConcurrentQueue<string>();
    private string _fileDir;
    private double result = 0.0;
    private object locker = new object();
    
    private void ThreadRun()
    {
        while (!_fileNames.IsEmpty)
        {
            string fileName;
            if (!_fileNames.TryDequeue(out fileName))
            {
                continue;
            }

            var lines = File.ReadLines(fileName).ToArray();
            
            var operation = int.Parse(lines[0]);
            var numbers = lines[1];

            double ans = 0.0;
            
            if (operation == 2)
            {
                ans = 1.0;
            }

            foreach (var num in numbers.Split(" "))
            {
                Console.WriteLine(num);
                double number = double.Parse(num);
                switch (operation)
                {
                    case 1:
                        ans += number;
                        break;
                    case 2:
                        ans *= number;
                        break;
                    case 3:
                        ans += number * number;
                        break;
                }
            } 
            
            lock (locker)
            {
                result += ans;
            }
        }
    }
    
    public void Calculate(string fileDir, string outFileDir, int threadsCount)
    {
        result = 0.0;
        _fileDir = fileDir;
        foreach (var fileName in Directory.GetFiles(fileDir))
        {
            _fileNames.Enqueue(fileName);
        }

        var threads = new List<Thread>();
        for (int i = 0; i < threadsCount; i++)
        {
            threads.Add(new Thread(ThreadRun));
        }

        foreach (var thread in threads)
        {
            thread.Start();
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }

        File.WriteAllText(outFileDir + "/out.dat", result.ToString());
    }
}