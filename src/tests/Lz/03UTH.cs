namespace EventBus
{
    public class Writer
    {
        private string name;
        private EventBus eventBus;
        
        public Writer(string _name, EventBus _eventBus)
        {
            name = _name;
            eventBus = _eventBus;
        }

        public void WriteEvent()
        {
            eventBus.Post(name);
        }
    }
}
