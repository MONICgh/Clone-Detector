namespace Task3;

public class Child
{
    private Parent _parent;

    public Child()
    {
        _parent = new Parent();
    }

    public int Plus1(int a)
    {
        return _parent.Plus1(a);
    }
    
    // override example:
    public int PlusBonus(int a)
    {
        return a * 2;
    }
}