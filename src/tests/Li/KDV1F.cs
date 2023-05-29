using System.Runtime.ExceptionServices;

namespace HW_08;

public class ExceptionWorker
{
    private ExceptionDispatchInfo? _info;

    public ExceptionWorker()
    {
    }

    public void RunComplicatedLogicWhichIsDefinitelySafe()
    {
        try
        {
            throw new Exception("Hey msg");
        }
        catch (Exception e)
        {
            _info = ExceptionDispatchInfo.Capture(e);
        }
    }

    public void Getter()
    {
        _info?.Throw();
    }
}
