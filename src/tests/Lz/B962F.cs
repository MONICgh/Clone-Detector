using System;

namespace EventBusLib
{
    public interface ISubscriber
    {
        void OnEvent(string message);
    }

    public class Subscriber : ISubscriber
    {
        public void OnEvent(string message)
        {
            Console.WriteLine($"Got the message: {message}");
        }
    }
}