using System.Globalization;

namespace Calculator;

public enum Operation
{
    Add = 1,
    Mult = 2,
    SumSquares = 3
}

public static class Utils
{
    public static (Operation, float, float) ParseOperation(string filename)
    {
        var file = File.OpenText(filename);
        var operation = (Operation)int.Parse(file.ReadLine() ?? throw new InvalidOperationException());
        var numbers = file.ReadLine()!
            .Split(" ")
            .Select(it => float.Parse(it, CultureInfo.InvariantCulture))
            .ToList();
        return (operation, numbers[0], numbers[1]);
    }

    public static float Calculate(Operation op, float number1, float number2)
    {
        return op switch
        {
            Operation.Add => number1 + number2,
            Operation.Mult => number1 * number2,
            Operation.SumSquares => number1 * number1 + number2 * number2,
            _ => throw new ArgumentOutOfRangeException(nameof(op), op, null)
        };
    }

    public static void SaveResult(string filename, float result)
    {
        var file = File.AppendText(filename);
        file.Write(result.ToString(CultureInfo.InvariantCulture));
        file.Close();
    } 
}