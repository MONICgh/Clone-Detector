using System.IO;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Text;

namespace task1
{
   class Program
    {
        const int N = 100000000;
       
        public static void WriteToFile(string path)
        {
            using (FileStream fs = File.Create(path))
            using (TextWriter writer = new StreamWriter(fs))
            {
                for (long i = 0; i < N; ++i)
                {
                    long randomNumber = (i * 48107653L + 29L) % N;
                    var formatedNumber = string.Format("{0:d9}", randomNumber);
                    writer.WriteLine(formatedNumber);
                }
            }
        }
        public static void Main(string[] args)
        {
            string path = "C:\\Users\\Anastasiia\\source\\repos\\task1\\BigRandomNumbers.txt";
            WriteToFile(path);
            Console.WriteLine("ok");
            
        }
    }
}
