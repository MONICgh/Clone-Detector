namespace HW_05.EventBusImpl;

public class ClassCounter10
{
    public delegate void MethodContainer(int x);

    public event MethodContainer Push = null!;

    public void Count()
    {
        for (var i = 1; i <= 100; i++)
        {
            if (i % 10 == 0)
            {
                Push(i);
            }
        }
    }
}
