using System.Reflection;

namespace HW_10;

public class BlackBox
{
    private int _innerValue;
    private BlackBox(int innerValue)
    {
        _innerValue = innerValue;
    }
    private BlackBox()
    {
        _innerValue = 0;
    }
    private void Add(int addend)
    {
        _innerValue += addend;
    }
    private void Subtract(int subtrahend)
    {
        _innerValue -= subtrahend;
    }
    private void Multiply(int multiplier)
    {
        _innerValue *= multiplier;
    }
    private void Divide(int divider)
    {
        _innerValue /= divider;
    }
}

class ReflectionBlackBoxRunner
{
    private Type _type = typeof(BlackBox);
    private readonly BlackBox _box;

    public ReflectionBlackBoxRunner()
    {
        var emptyParameters = Array.Empty<object>();
        var constructorInfo = _type.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, Array.Empty<Type>());

        var result = constructorInfo!.Invoke(emptyParameters);
        _box = (BlackBox)result;
    }

    public void run()
    {
        while (true)
        {
            var command = Console.ReadLine();
            if (command == null)
                break;
            if (command.ToLower() == "exit")
                break;
            try
            {
                var result = ExecuteCommandAndGetValue(command);
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught: " + e);
            }
        }

    }

    public int ExecuteCommandAndGetValue(string command)
    {
        var data = command.Split(' ');
        var methodInfo = _type.GetMethod(data[0], BindingFlags.Instance |
            BindingFlags.Public |
            BindingFlags.NonPublic);
        if (methodInfo is null)
        {
            throw new TargetException("Wrong method");
        }
        methodInfo.Invoke(_box, parameters: new object[] { int.Parse(data[1]) });

        var fieldInfo = _type.GetField("_innerValue", BindingFlags.Instance |
            BindingFlags.Public |
            BindingFlags.NonPublic)!;
        return (int)fieldInfo.GetValue(_box)!;

    }
}
