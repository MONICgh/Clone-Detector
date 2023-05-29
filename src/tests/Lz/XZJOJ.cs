namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var eventBus = new EventBus();

            var publisher1 = new Publisher("A");
            var publisher2 = new Publisher("B");

            var subscriber1 = new Subscriber("s1");
            var subscriber2 = new Subscriber("s2");

            eventBus.AddPublisher(publisher1);
            eventBus.AddPublisher(publisher2);

            eventBus.Subscribe("A", subscriber1);
            eventBus.Subscribe("B", subscriber2);
            publisher1.Post();
            publisher2.Post();
            Console.WriteLine();
            /*  Publisher A posted a new post
                Subscriber s1 read the new post
                Publisher B posted a new post
                Subscriber s2 read the new post 
            */

            eventBus.Subscribe("A", subscriber2);
            eventBus.Unsubscribe("B", subscriber2);
            publisher1.Post();
            publisher2.Post();
            /*  Publisher A posted a new post
                Subscriber s1 read the new post
                Subscriber s2 read the new post
                Publisher B posted a new post
             */



        }
    }
}