namespace EventBus
{
    public class Reader
    {
        private string name;
        public Reader(string _name)
        {
            name = _name;
        }

        public void OnEvent(string author)
        {
            Console.WriteLine("{0} read message from {1}", name, author);
        }
    }
}
