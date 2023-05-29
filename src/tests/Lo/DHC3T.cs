using System.Globalization;
using System.Xml.Linq;

namespace task4
{
    class Program
    {
        static readonly string filesDirectory = "C:\\Users\\Anastasiia\\source\\repos\\task4\\testFiles\\";
        private static object locker = new object();
        private static float resultsSum = 0;

        static (int, float, float) ReadFile(string filename)
        {
            using (var reader = File.OpenText(filesDirectory + filename))
            {
                int operation = int.Parse(reader.ReadLine());
                var args = reader.ReadLine().Split(" ").Select(item => float.Parse(item, CultureInfo.InvariantCulture)).ToList();
                return (operation, args[0], args[1]);

            }
        }

        static float Calculate(int operation, float a, float b) =>
            operation switch
            {
                1 => a + b,
                2 => a * b,
                3 => a * a + b * b,
                _ => throw new Exception("Unknown operation")
            };

        static void ThreadAction(List<String> files)
        {
            float sum = 0;
            foreach (string filename in files)
            {
                var (operation, a, b) = ReadFile(filename);
                float result = Calculate(operation, a, b);
                sum += result;
            }
            lock (locker)
            {
                resultsSum += sum;
            }
        }
        
        static void RunCalculations(int threadsNumber, List<String> files)
        {
            threadsNumber = Math.Min(threadsNumber, files.Count);
            Thread[] threadsArray = new Thread[threadsNumber];
            var threadsFileLists = new List<List<string>>(threadsNumber);
            int filesPerThread = (files.Count + threadsNumber - 1) / threadsNumber;

            for (int i = 0; i < threadsNumber; i++)
            {
                threadsFileLists.Add(new List<string>());
            }

            for (int i = 0; i < files.Count; i++)
            {
                threadsFileLists[i / filesPerThread].Add(files[i]);
            }

            for (int i = 0; i < threadsNumber; i++)
            {
                int temp = i;
                threadsArray[i] = new Thread(() => ThreadAction(threadsFileLists[temp]));
                threadsArray[i].Start();
            }

            for (int i = 0; i < threadsNumber; i++)
            {
                threadsArray[i].Join();
            }

        }
        public static void Main(string[] args)
        {
            Console.Write("Threads number: ");
            var threadsCount = int.Parse(Console.ReadLine());
            var files = new List<String>();

            for (int i = 1; i <= 3; i++)
            {
                files.Add(i.ToString() + ".txt");
            }

            RunCalculations(threadsCount, files);
            using (var writer = File.AppendText(filesDirectory + "out.dat"))
            {
                writer.WriteLine(resultsSum.ToString());
            }
            /*Threads number: 3
             out.dat: 1,03      (0.1 + 0.2 + 0.3 * 0.4 + 0.5 + 0.5 + 0.6 * 0.6 = 1.03)
            */
        }
    }
}
