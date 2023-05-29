using System.Reflection;

namespace BlackBoxTask;

public class BlackBoxReflector
{
    private BlackBox _blackBox;

    public BlackBoxReflector()
    {
        var type = typeof(BlackBox);
        var constructorInfo = type.GetTypeInfo().DeclaredConstructors.First(
            c => c.GetParameters()[0].ParameterType == Type.GetType("System.Int32")
        );
        _blackBox = (BlackBox)constructorInfo.Invoke(new object[] {0});
    }

    public int GetValue()
    {
        var fieldInfo = _blackBox.GetType().GetTypeInfo().GetDeclaredField("innerValue");
        return (int)fieldInfo.GetValue(_blackBox);
    }

    public void Add(int x)
    {
        var methodInfo = _blackBox.GetType().GetTypeInfo().GetDeclaredMethod("Add");
        methodInfo?.Invoke(_blackBox, new object?[] { x });
    }
    
    public void Subtract(int x)
    {
        var methodInfo = _blackBox.GetType().GetTypeInfo().GetDeclaredMethod("Subtract");
        methodInfo?.Invoke(_blackBox, new object?[] { x });
    }
    
    public void Multiply(int x)
    {
        var methodInfo = _blackBox.GetType().GetTypeInfo().GetDeclaredMethod("Multiply");
        methodInfo?.Invoke(_blackBox, new object?[] { x });
    }
    
    public void Divide(int x)
    {
        var methodInfo = _blackBox.GetType().GetTypeInfo().GetDeclaredMethod("Divide");
        methodInfo?.Invoke(_blackBox, new object?[] { x });
    }
}