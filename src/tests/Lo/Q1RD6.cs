
using System.Collections.Generic;
namespace task3
{
    class Program
    {
        private const int maxStringsCount = 100;
        private static List<String> sortedStrings = new List<String>();
        private static object locker = new object();

        static void ThreadAction(string str)
        {
            Thread.Sleep(str.Length * maxStringsCount);
            lock (locker)
            {
                sortedStrings.Add(str);
            }
        }

        static List<String> SleepSort(List<String> strings)
        {
            var threads = new List<Thread>();
            foreach(string str  in strings)
            {
                threads.Add(new Thread(() => ThreadAction(str)));
            }

            threads.ForEach(thread => thread.Start());
            threads.ForEach(thread => thread.Join());

            return sortedStrings;
        }

        public static void Main(string[] args)
        {
            var myStrings = new List<string>
            {
                "sodium", "potassium", "boron", "copper", "silver", "gold", "platinum", "arsenic"

            };
            var mySortedstrings = SleepSort(myStrings);
            Console.WriteLine(string.Join(" ", mySortedstrings)); //gold boron sodium copper silver arsenic platinum potassium
        }
    }
}