using BindingFlags = System.Reflection.BindingFlags;

namespace BlackBoxTask;

public class MyBlackBox
{
    private BlackBox blackbox;

    public MyBlackBox()
    {
        var type = typeof(BlackBox);
        blackbox = (BlackBox)type.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, Type.EmptyTypes)!
            .Invoke(Array.Empty<object>());
    }

    public void DoMethod(string method, int val)
    {
        var methodInfo = typeof(BlackBox).GetMethod(method, BindingFlags.NonPublic | BindingFlags.Instance);
        if (methodInfo == null)
        {
            throw new Exception("No such method!");
        }

        methodInfo.Invoke(blackbox, new object[] { val });
    }

    public int GetInnerValue()
    {
        return (int)typeof(BlackBox).GetField("innerValue", BindingFlags.NonPublic | BindingFlags.Instance)!
            .GetValue(blackbox)!;
    }
}