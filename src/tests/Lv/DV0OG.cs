using System;
using System.Linq;

namespace Grouping
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] ss = { "Это что же получается: ходишь, ходишь в школу, а потом бац - вторая смена", "В субботу у них классное мероприятие на весь день. к сожалению, не будет.", "Тем не менее для управления порядком обрабатываемых элементов в многомерных массивах можно использовать вложенный цикл for." };
            foreach (var s in ss)
            {
                Console.WriteLine("");
                Console.WriteLine(s);

                var words = s.Split(" ,.:-".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                var ans = words
                    .GroupBy(x => x.Length)
                    .OrderBy(grp => -grp.Count())
                    .Select(grp => new {
                        Name = grp.Key,
                        Len = grp.First().Length,
                        Count = grp.Count(),
                        Words = grp.Select(p => p)
                    });

                foreach (var group in ans)
                {
                    Console.WriteLine($"Группа {group.Name}. Длина {group.Len}. Количество {group.Count} ");
                    foreach (var word in group.Words)
                    {
                        Console.WriteLine(word);
                    }
                }
            }
        }
    }
}