using System;
using System.Collections.Generic;

namespace EventBusLib
{
    public class EventBus
    {
        private readonly Dictionary<string, IPublisher> _publishers = new Dictionary<string, IPublisher>();

        public void NewPublisher(IPublisher publisher)
        {
            _publishers.Add(publisher.Username(), publisher);
        }

        public void Subscribe(string publisherName, ISubscriber user)
        {
            if (!_publishers.ContainsKey(publisherName))
            {
                throw new ArgumentException("No such publisher!");
            }
            _publishers[publisherName].OnPost += user.OnEvent;
        }
        
        public void Unsubscribe(string publisherName, ISubscriber user)
        {   
            if (!_publishers.ContainsKey(publisherName))
            {
                throw new ArgumentException("No such publisher!");
            }
            _publishers[publisherName].OnPost -= user.OnEvent;
        }
    }
}