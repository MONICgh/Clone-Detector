namespace EventBus
{
    public delegate void ReaderEvent(string s);
    public class EventBus
    {
        private event ReaderEvent Events = null;

        public EventBus() { }

        public void Post(string s)
        {
            Events?.Invoke(s);
        }

        public void Subscribe(ReaderEvent readerEvent)
        {
            Events += readerEvent;
        }

        public void Unsubscribe(ReaderEvent readerEvent)
        {
            Events -= readerEvent;
        }
    }
}