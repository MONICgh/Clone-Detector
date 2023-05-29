namespace Task1;

public class Simulation
{
    public Simulation(int maxCounter, int beesCounter, int runningMs)
    {
        _maxCounter = maxCounter;
        for (int i = 0; i < beesCounter; i++)
        {
            var index = i;
            Task.Factory.StartNew(() => Bee(index), TaskCreationOptions.AttachedToParent);
        }
        Thread.Sleep(runningMs);
    }
    
    private readonly object _potLocker = new object();
    private readonly Random _random = new Random();
    private int _potCounter = 0;
    private readonly int _maxCounter = 0; 

    void Bee(int number)
    {
        while (true)
        {
            Thread.Sleep(_random.Next(1000));
            Console.WriteLine("Пчела #" + number + " собрала мёд");
            lock (_potLocker)
            {
                while (_potCounter == _maxCounter)
                {
                    Monitor.Wait(_potLocker);
                }
                
                _potCounter++;
                Console.WriteLine("Пчела #" + number + " положила мёд в горшок. В горшке сейчас " + _potCounter + " мёда");

                if (_potCounter == _maxCounter)
                {
                    Console.WriteLine("Пчела #" + number + " будит медведя");
                    Task.Run(() => Bear());
                }
                Monitor.PulseAll(_potLocker);
            }
        }
    }

    void Bear()
    {
        lock (_potLocker)
        {
            while (_potCounter < _maxCounter)
            {
                Monitor.Wait(_potCounter);
            }

            Console.WriteLine("Мишка ест мёд!");
            Thread.Sleep(_potCounter * 100);
            _potCounter = 0;
            Console.WriteLine("Мишка съел мёд! И опять засыпает");
        }
    }
}