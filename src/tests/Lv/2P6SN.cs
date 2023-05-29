using System;
using System.Linq;

namespace Task3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            const string text = "Это что же получается: ходишь, ходишь в школу, а потом бац - вторая смена";
            var punctuation = text.Where(char.IsPunctuation).Distinct().ToArray();
            var words = text.Split().Select(item => item.Trim(punctuation)).Where(item => item.Length > 0);
            var groups = words.GroupBy(item => item.Length).Select(item => item.ToList())
                .OrderByDescending(item => item.Count);
            foreach (var group in groups)
            {
                Console.WriteLine("Длина " + group.First().Length + ". Количество " + group.Count + '.');
                Console.WriteLine(string.Join("\n", group) + '\n');
            }
        }
    }
}