namespace task1
{
    class Publisher
    {
        public delegate void Action();
        public event Action Poster;
        public string Name;
        
        public Publisher(string name)
        {
            Name = name;    
        }

        public void Post()
        {
            Console.WriteLine($"Publisher {Name} posted a new post");
            Poster?.Invoke();

        }
    }
}
