namespace FooBar;

public class MutexLocker
{
    public int Index = 0;
    public Mutex ObjMutex = new Mutex();
}