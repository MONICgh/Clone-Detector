namespace Task2;

public class ImplClass: AbstractClass, Interface1, Interface2
{
    public override string Info()
    {
        return "Info() from AbstractClass";
    }
    
    string Interface1.Info()
    {
        return "Info() from Interface1";
    }

    string Interface2.Info()
    {
        return "Info() from Interface2";
    }
}