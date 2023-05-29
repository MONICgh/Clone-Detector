
namespace task1
{
    class Bear
    {

        public Bear() { }


        public  void Work(ref HoneyPot pot)
        {
            while (true)
            {
                lock(pot)
                {
                    while(!pot.IsFull())
                    {
                        Monitor.Wait(pot);
                    }

                    pot.Empty();
                    Console.WriteLine("Bear: 0");
                    Monitor.PulseAll(pot);
                }
            }
        }
    }
}
