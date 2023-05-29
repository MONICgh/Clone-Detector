using NUnit.Framework;

namespace Hairdresser
{
    internal class BarbershopTest
    {
        [Test]
        public void Test1()
        {
            Barbershop brb = new(1);
            brb.NewClient("Leha");
            brb.NewClient("Igor");
            brb.NewClient("Vasya");
            Thread.Sleep(7000);

            string[] result = brb.FinishedClients();
            Assert.True(result.Length == 1 && result[0] == "Leha");
        }

        [Test]
        public void Test2() 
        {
            Barbershop brb = new(2);
            brb.NewClient("Leha");
            brb.NewClient("Igor");
            brb.NewClient("Vasya");
            Thread.Sleep(13000);

            string[] result = brb.FinishedClients();
            Console.WriteLine(result.Length);
            Console.WriteLine(result[0]);
            Console.WriteLine(result[1]);
            Assert.True(result.Length == 2);
        }

        [Test]
        public void Test3()
        {
            Barbershop brb = new(4);
            brb.NewClient("Leha");
            brb.NewClient("Igor");
            brb.NewClient("Vasya");
            Thread.Sleep(20000);

            string[] result = brb.FinishedClients();
            Assert.True(result.Length == 3);
        }
    }
}
