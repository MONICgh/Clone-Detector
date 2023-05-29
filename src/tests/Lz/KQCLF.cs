using System;

namespace EventBus
{
    public class TestsEventBus
    {
        public void TestAll()
        {
            Test1();
            Test2();
            Test3();
        }

        public void Test1()
        {
            Console.WriteLine("Test 1.");
            BankAccountPublisher publisher = new BankAccountPublisher();
            Subscriber subscriber = new Subscriber();

            publisher.BankAccountChanged += subscriber.GetNotificationFromBankAccount;
            publisher.Put(30);
            Console.WriteLine("Test finished.");
        }
        
        public void Test2()
        {
            Console.WriteLine("Test 2.");
            BankAccountPublisher publisher = new BankAccountPublisher();
            Subscriber subscriber1 = new Subscriber();
            Subscriber subscriber2 = new Subscriber();

            publisher.BankAccountChanged += subscriber1.GetNotificationFromBankAccount;
            publisher.BankAccountChanged += subscriber2.GetNotificationFromBankAccount;
            publisher.Put(30);
            Console.WriteLine("Test finished.");
        }
        
        public void Test3()
        {
            Console.WriteLine("Test 3.");
            BankAccountPublisher publisher = new BankAccountPublisher();
            Subscriber subscriber1 = new Subscriber();
            Subscriber subscriber2 = new Subscriber();
            publisher.Put(30);
            Console.WriteLine("Test finished.");
        }
    }
}