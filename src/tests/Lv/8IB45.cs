using System.Collections.Generic;
using System.Linq;


namespace task4
{
    class Program
    {
        static string Translate(int n, List<string> text, Dictionary<string, string> rusEngDictionary)
        {
            var chunkedText = text
                .Select(word => rusEngDictionary[word].ToUpper())
                .Chunk(n)
                .Select(sublist => string.Join(" ", sublist));
            return string.Join("\n", chunkedText);
        }
        static void Main(string[] args)
        {
            var rusEngDictionary = new Dictionary<string, string>()
            {
                {"This", "это"}, {"dog", "собака"}, {"eats", "ест"}, {"too", "слишком"},
                {"much", "много"}, {"vegetables", "овощей"}, {"after", "после"}, {"lunch", "обед"}
            };

            var text = "This dog eats too much vegetables after lunch".Split(" ").ToList();
            Console.WriteLine(Translate(3, text, rusEngDictionary));

            /*
             * ЭТО СОБАКА ЕСТ
               СЛИШКОМ МНОГО ОВОЩЕЙ
               ПОСЛЕ ОБЕД
             */
        }
    }
}