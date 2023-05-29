using System;

namespace Lab5
{
    public delegate void Notice();
    public delegate void Post();
    
    public class Subscriber
    {
        string name;
        public Subscriber(string name)
        {
            this.name = name;
        }
        public void onEvent()
        {
            Console.WriteLine("Message recieved from {0}!", name);
        }
    }

    public class Publisher
    {
        string name;
        event Post bus;

        public Publisher(string name)
        {
            this.name = name;
        }

        public void ConnectBus(EventBus b)
        {
            bus += b.Broadcast;
        }

        public void Post()
        {
            Console.WriteLine("Message posted from {0}!", name);
            bus?.Invoke();
        }
    }


    public class EventBus
    {
        private event Notice subs;

        public void Subscribe(Subscriber s) 
        {
            subs += s.onEvent;
        }
        public void Unsubscribe(Subscriber s)
        {
            subs -= s.onEvent;
        }

        public void Broadcast()
        {
            subs?.Invoke();
        }
    }
}
