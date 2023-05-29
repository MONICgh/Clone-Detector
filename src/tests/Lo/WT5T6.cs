namespace Application
{
    class Task3
    {
        static private int SLEEP_K = 100;
        static private object _lock = new object();

        static void SleepAndDo(string str, List<string> result)
        {
            Thread.Sleep(str.Length * SLEEP_K);
            lock (_lock)
            {
                result.Add(str);
            }

            // Console.WriteLine(str);
        }
        
        static void SleepSort(List<string> strings)
        {
            var result = new List<string>();
            var threads = new List<Thread>();
            foreach (var str in strings)
            {
                var thread = new Thread(() => SleepAndDo(str, result));
                threads.Add(thread);
                thread.Start();
            }
            foreach (var thread in threads)
            {
                thread.Join();
            }
            Console.WriteLine(String.Join("\n", result));
        }
        
        static void Main()
        {
            var strings = new List<string>()
            {
                "А.", "Сортировка", "в", "потоках", "(1", "балл)", "Реализуйте", "алгоритм", "сортировки", "с", "асимптотикой", "O(N)", "(по", "процессорному", "времени).", "Пусть", "на", "вход", "подается", "массив", "из", "не", "более", "100", "строк", "различной", "длины.", "Вам", "необходимо", "вывести", "эти", "строки,", "отсортированные", "по", "длине.", "Строки", "одинаковой", "длины", "могут", "выводиться", "в", "произвольном", "порядке.", "Для", "каждой", "строки", "создайте", "поток", "и", "передайте", "ему", "эту", "строку", "в", "качестве", "параметра.", "Поток", "должен", "уснуть", "на", "время,", "пропорциональное", "длине", "переданной", "строки", "(необходимо", "вызвать", "метод", "Sleep).", "Затем", "поток", "выводит", "строку", "на", "консоль", "и", "завершается."
            };
            SleepSort(strings);
        }
    }
}
