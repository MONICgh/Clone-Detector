using System;
using System.Collections.Generic;
using System.Linq;

namespace Translator
{
    class Program
    {
        static Dictionary<string, string> dict = new Dictionary<string, string>
        {
            {"This", "этот"},
            {"dog", "собака"},
            {"eats", "есть"},
            {"too", "слишком"},
            {"much", "много"},
            {"vegetables", "овощи"},
            {"after", "после"},
            {"lunch", "обед"}
        };

        static void CreateBook(string s, int n)
        {
            Console.WriteLine(s);
            var words = s.Split(" ,.:-".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            var book = words
                .Select(x => dict[x].ToUpper())
                .Select((x, i) => new { Key = i / n, Value = x })
                .GroupBy(x => x.Key);

            foreach (var page in book)
            {
                foreach (var word in page)
                {
                    Console.Write($"{word.Value} ");
                }
                Console.WriteLine($"// {page.Key + 1} страница");
            }
        }
        static void Main(string[] args)
        {
            CreateBook("This dog eats too much vegetables after lunch", 3);       
        }
    }
}
