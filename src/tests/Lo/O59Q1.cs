object o = new();

Command ReadCommand(string filename)
{
    using var reader = File.OpenText("../../../test_files/" + filename);
    
    var operation = int.Parse(reader.ReadLine()!);
    var numbers = reader
        .ReadLine()!
        .Split(" ")
        .Select(Convert.ToDouble)
        .ToList();
    
    return new Command(operation, numbers);
}

void WriteResult(string filename, double result)
{
    using var writer = File.AppendText("../../../test_files/out.dat");
    
    writer.Write("Result for file " + filename + ": ");
    writer.WriteLine(result);
}

void ComputeFile(string fileName)
{
    var command = ReadCommand(fileName);
    var result = command.Compute();
    lock (o)
    {
        WriteResult(fileName, result);
    }
}

void RunFileCalculator(int threadsCnt, List<string> filesList)
{
    var batchSize = (filesList.Count + threadsCnt - 1) / threadsCnt;
    var batches = filesList.Chunk(batchSize);

    var threads = batches.Select(batch => {
        return new Thread(() => batch.ToList().ForEach(ComputeFile));
    }).ToList();

    threads.ForEach(t => t.Start());
    threads.ForEach(t => t.Join());
}

RunFileCalculator(4, new List<string>
{
    "sum1.txt",
    "sum2.txt",
    "sum3.txt",
    "prod1.txt",
    "prod2.txt",
    "prod3.txt",
    "sq_sum1.txt",
    "sq_sum2.txt",
    "sq_sum3.txt",
});

record Command(int Operation, List<double> Operands)
{
    public double Compute()
    {
        return Operation switch
        {
            1 => Operands.Sum(),
            2 => Operands.Aggregate((a, b) => a * b),
            3 => Operands.Select(a => a * a).Sum(),
            _ => throw new Exception("Unknown operation: " + Operation)
        };
    }
}