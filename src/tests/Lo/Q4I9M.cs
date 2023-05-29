using System.Collections.Concurrent;

namespace Calculator;

class Calculator
{
    private readonly BlockingCollection<float> _results = new ();
    private readonly string _directoryPath;
    private readonly string _outputFile;
    private readonly int _threadCount;

    public Calculator(string directoryPath, string outputFile, int threadCount)
    {
        _directoryPath = directoryPath;
        _outputFile = outputFile;
        _threadCount = threadCount;
    }

    private void Task(IEnumerable<string> filenames)
    {
        foreach (var filename in filenames)
        {
            var (op, num1, num2) = Utils.ParseOperation(filename);
            var result = Utils.Calculate(op, num1, num2);
            _results.Add(result);
        }
    }
    
    public void Run()
    {
        var files = Directory.GetFiles(_directoryPath);
        var results = new BlockingCollection<float>();

        var chunkedFiles = files.Chunk((files.Length + _threadCount - 1) / _threadCount);
        var threads = chunkedFiles.Select(chunk => new Thread(() => Task(chunk))).ToList();
        Console.WriteLine($"Start {_threadCount} threads");
        threads.ForEach(it => it.Start());
        threads.ForEach(it => it.Join());
        Console.WriteLine($"Join threads");
        Utils.SaveResult(_outputFile, _results.Sum(it => it));
        Console.WriteLine($"Save result to {_outputFile}");
        
    }
}