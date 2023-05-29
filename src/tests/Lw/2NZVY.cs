namespace Hairdresser
{
    public class Barbershop
    {
        private readonly int waitSeat;
        public List<string> processedClients;

        public Barbershop(int _waitSeat)
        {
            waitSeat = _waitSeat;
            processedClients = new List<string>();
            ThreadPool.SetMaxThreads(1, 1);
        }
        public void NewClient(string name)
        {
            if (ThreadPool.PendingWorkItemCount < waitSeat)
            {
                ThreadPool.QueueUserWorkItem((state) =>
                {
                    Thread.Sleep((new Random().Next(10) + 1) * 500);
                    processedClients.Add(name);
                });
            }
        }

        public string[] FinishedClients()
        {
            return processedClients.ToArray();
        }
    }
}