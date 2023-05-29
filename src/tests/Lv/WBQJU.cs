using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Application
{
    class Task3
    {
        static void Main()
        {
            Regex rgx = new Regex(@"[^a-zA-Zа-яА-Я]+");
            var sentence = "Это что же получается: ходишь, ходишь в школу, а потом бац - вторая смена";
            var res = rgx.Split(sentence)
                .GroupBy(n => n.Length)
                .Select((n, ind) => new { group = n, count = n.Count(), index = ind+1 })
                .OrderBy(n => -n.count)
                .Select(n => string.Format("Группа {0}. Длина {1}. Количество {2}\n", n.index, n.group.First().Count(), n.count) + string.Join("\n", n.group))
                .ToList();
            Console.WriteLine(string.Join("\n\n", res));
        }
    }
}
