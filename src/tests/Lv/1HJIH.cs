using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Application
{
    class Task4
    {
        static void Main()
        {
            var dictionary = new Dictionary<string, string>() {
                { "this", "эта"},
                { "dog", "собака"},
                { "eats", "ест"},
                { "too", "слишком"},
                { "much", "много"},
                { "vegetables", "овощей"},
                { "after", "после"},
                { "lunch", "обеда"}
            };
            var N = 3;
            var sentence = "This dog eats too much vegetables after lunch";
            var book = sentence.Split(" ")
                .Select(n => dictionary[n.ToLower()].ToUpper())
                .Chunk(N)
                .Select(n => string.Join(" ", n.ToList()))
                .ToList();
            Console.WriteLine(string.Join("\n", book));
        }
    }
}
