namespace Application
{
    public class Message
    {
        public Message(object Data) {
            this.Data = Data;
        }

        public object? Data;
    }


    public interface ISubscriber
    {
        abstract object? OnEvent(Message message);
    }

    class Subscriber1 : ISubscriber
    {
        object? ISubscriber.OnEvent(Message message)
        {
            Console.WriteLine("Subscriber1.OnEvent: {0}", message.Data);
            return message.Data;
        }
    }

    class Subscriber2 : ISubscriber
    {
        object? ISubscriber.OnEvent(Message message)
        {
            Console.WriteLine("Subscriber2.OnEvent: {0}", message.Data);
            return message.Data;
        }
    }


    public interface IPublisher
    {
        abstract public object? Post(Message message);

        abstract public void Subscribe(ISubscriber subscriber);

        abstract public void Unsubscribe(ISubscriber subscriber);
    }

    class Publisher : IPublisher
    {
        private EventBus eventBus = EventBus.Instance;

        object? IPublisher.Post(Message message)
        {
            return eventBus.Post(this, message);
        }

        void IPublisher.Subscribe(ISubscriber subscriber)
        {
            eventBus.Subscribe(this, subscriber);
        }

        void IPublisher.Unsubscribe(ISubscriber subscriber)
        {
            eventBus.Unsubscribe(this, subscriber);
        }

        public object? Post(Message message)
        {
            return ((IPublisher)this).Post(message);
        }

        public void Subscribe(ISubscriber subscriber)
        {
            ((IPublisher)this).Subscribe(subscriber);
        }

        public void Unsubscribe(ISubscriber subscriber)
        {
            ((IPublisher)this).Unsubscribe(subscriber);
        }
    }

    class Publisher1 : Publisher {}

    class Publisher2 : Publisher {}


    delegate object? OnEvent(Message message);
    public class EventBus
    {
        private EventBus() {}

        private static EventBus? instance;

        public static EventBus Instance {
            get {
                if (instance == null)
                {
                    instance = new EventBus();
                }
                return instance;
            }
        }

        private Dictionary<IPublisher, OnEvent> events = new Dictionary<IPublisher, OnEvent>();

        public void Subscribe(IPublisher publisher, ISubscriber subscriber)
        {
            if (!events.ContainsKey(publisher)) {
                events[publisher] = null;
            }
            events[publisher] += subscriber.OnEvent;
        }

        public void Unsubscribe(IPublisher publisher, ISubscriber subscriber)
        {
            if (events.ContainsKey(publisher))
            {
                events[publisher] -= subscriber.OnEvent;
                if (events[publisher] == null)
                {
                    events.Remove(publisher);
                }
            }
        }

        public object? Post(IPublisher publisher, Message message)
        {
            if (events.ContainsKey(publisher))
            {
                return events[publisher]?.Invoke(message);
            }
            return null;
        }
    }

    class Task1
    {
        static void Main()
        {
            Publisher1 publisher1 = new Publisher1();
            Publisher2 publisher2 = new Publisher2();
            Publisher2 publisher3 = new Publisher2();
            Subscriber1 subscriber1 = new Subscriber1();
            Subscriber2 subscriber2 = new Subscriber2();

            publisher1.Subscribe(subscriber1);
            publisher1.Subscribe(subscriber2);
            publisher2.Subscribe(subscriber1);
            publisher3.Subscribe(subscriber2);
            publisher1.Post(new Message("msg"));
            publisher2.Post(new Message("msg2"));
            publisher3.Post(new Message("msg3"));
            publisher2.Unsubscribe(subscriber1);
            publisher2.Unsubscribe(subscriber2);
            publisher3.Unsubscribe(subscriber2);
            publisher1.Post(new Message("msg4"));
            publisher2.Post(new Message("msg5"));
        }
    }
}
