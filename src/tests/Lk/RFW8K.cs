namespace Interface
{
    public class D : C, IA, IB
    {
        public override string HelloWorld(int x)
        {
            return "Hello world! " + x.ToString();
        }

        string IA.HelloWorld(int x)
        {
            return "HeLlO WoRlD! " + (x + 1).ToString();
        }

        string IB.HelloWorld(int x)
        {
            return "World hello! " + (x + 2).ToString();
        }
    }
}
