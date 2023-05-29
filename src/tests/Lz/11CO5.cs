namespace task1
{
    internal class Subscriber
    {
        public string Name;

        public Subscriber(string name)
        {
            Name = name;
        }   

        public void OnEvent()
        {
            Console.WriteLine($"Subscriber {Name} read the new post");
        }
    }
}
