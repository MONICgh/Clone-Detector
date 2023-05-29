namespace HW_05.EventBusImpl;

public class ClassCounter15
{
    public delegate void MethodContainer(int x);

    public event MethodContainer Push = null!;

    public void Count()
    {
        for (var i = 1; i <= 100; i++)
        {
            if (i % 15 == 0)
            {
                Push(i);
            }
        }
    }
}
