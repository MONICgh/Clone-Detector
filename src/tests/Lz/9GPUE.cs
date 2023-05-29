namespace task1
{
    class EventBus
    {
        private Dictionary<string, Publisher> systemPublishers;

        public EventBus() {
            systemPublishers = new Dictionary<string, Publisher>();
        }

        public void AddPublisher(Publisher publisher) {
            if (systemPublishers.ContainsKey(publisher.Name))
            {
                throw new Exception($"Publisher {publisher.Name} already exists");
            }
            else
            {
                systemPublishers[publisher.Name] = publisher;
            }
        }

        public void RemovePublisher(Publisher publisher)
        {
            systemPublishers.Remove(publisher.Name);
        }

        public void Subscribe(string name, Subscriber subscriber) {
            if (systemPublishers.ContainsKey(name))
            {
                systemPublishers[name].Poster += subscriber.OnEvent;
            }
            else
            {
                throw new Exception($"Publisher {name} does not exist");
            }
        }

        public void Unsubscribe(string name, Subscriber subscriber) {
            if (systemPublishers.ContainsKey(name))
            {
                systemPublishers[name].Poster -= subscriber.OnEvent;
            }
        }

        public string getPublishers()
        {
            string outputString = "";
            foreach (string name in systemPublishers.Keys)
            {
                outputString += $"{name}, ";
            }
            if (outputString.Length > 0)
            {
                outputString = outputString.Remove(outputString.Length - 2, 2);
            }
            return "{" + outputString + "}";
        }
    }
}
