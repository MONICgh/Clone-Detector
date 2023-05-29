using System.Linq;
using System.Text.RegularExpressions;

namespace task3
{
    class Program
    {
        const string punctuation = ".,;:!?()-'<>";
        static IEnumerable<char> TrimPunctuation(IEnumerable<char> words)
        {
            
            foreach (char symbol in punctuation)
            {
                words = words.Where(word => word != symbol);
            }
            return words;
        }

        static void SentenceGroupStatistics(string str)
        {
            IEnumerable<char> words = str;
            var groups = string.Join("", TrimPunctuation(words))
               .Split(" ")
               .Where(word => word.Length > 0)
               .GroupBy(word => word.Length)
               .OrderByDescending(group => group.Count());
            foreach (var group in groups)
            {
                Console.WriteLine($"Длина {group.Key}. Количество {group.Count()} ");
                foreach (var word in group)
                {
                    Console.WriteLine(word.ToLower());
                }
            }

        }
      
        static void Main(string[] args)
        {
            string str = "Это что же получается: ходишь, ходишь в школу, а потом бац - вторая смена";
            SentenceGroupStatistics(str);
            /*
             Длина 3. Количество 3
            это
            что
            бац
            Длина 6. Количество 3
            ходишь
            ходишь
            вторая
            Длина 5. Количество 3
            школу
            потом
            смена
            Длина 1. Количество 2
            в
            а
            Длина 2. Количество 1
            же
            Длина 10. Количество 1
            получается*/

        }
    }
}