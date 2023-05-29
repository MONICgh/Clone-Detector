namespace Interfaces
{
    public class ChildClass : AbstractClass, Interface1, Interface2
    {
        public override string Hello()
        {
            return "Hello from AbstractClass";
        }
        
        string Interface1.Hello()
        {
            return "Hello from Interface1";
        }

        string Interface2.Hello()
        {
            return "Hello from Interface2";
        }
    }
}