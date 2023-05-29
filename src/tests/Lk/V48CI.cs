namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            var cat = new Cat();
            cat.Say(); //Meow.Moore
            ((Mew)cat).Say(); //Meow
            ((Purr)cat).Say(); //Moore
        }
    }
}
