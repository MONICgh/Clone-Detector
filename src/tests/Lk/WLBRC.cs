namespace task2
{
    class Cat : Animal, Mew, Purr
    {
        public override void Say()
        {
            Console.WriteLine("Meow.Moore");
        }

        void Mew.Say()
        {
            Console.WriteLine("Meow");
        }

        void Purr.Say()
        {
            Console.WriteLine("Moore");
        }
    }
}
