using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Char = System.Char;

namespace MainTasks;

public abstract class WithName
{
    public abstract string Name { get; set; }
}

public class Tasks
{
    public static string Task1(IEnumerable<WithName> collection, string delimiter)
    {
        return collection.Skip(3).Select(it => it.Name).Aggregate((acc, x) => acc + delimiter + x);
    }

    public static IEnumerable<WithName> Task2(IEnumerable<WithName> collection)
    {
        return collection.Where((it, i) => it.Name.Length > i);
    }

    public static string Task3(string sentence)
    {
        var punctuationMarks = new List<Char> { ',', '.', '-', '!', '?', ':' };
        var groups = sentence
            .Split(' ')
            .Select(s => string.Join("", s.Where(c => !punctuationMarks.Contains(c))))
            .Select(s => s.ToLower())
            .Where(s => s.Length > 0)
            .GroupBy(
                it => it.Length
            )
            .Select((group, index) => new
            {
                Group = group,
                Index = index
            })
            .OrderBy(it => -it.Group.ToList().Count)
            .ThenBy(it => -it.Group.Key);

        var builder = new StringBuilder();
        foreach (var group in groups)
        {
            builder.AppendLine($"Группа {group.Index + 1}. Длина {group.Group.Key}. Количество {group.Group.ToList().Count}");
            foreach (var word in group.Group)
            {
                builder.AppendLine(word);
            }

            builder.AppendLine();
        }

        return builder.ToString();
    }

    public static List<string> Task4(string text, int n, Dictionary<string, string> dict)
    {
        return text
            .Split(" ")
            .Select(it => dict[it.ToLower()])
            .Select(it => it.ToUpper())
            .Chunk(n)
            .Select(it => string.Join(' ', it.ToList()))
            .ToList();
    }

    public static List<string> Task5(string sentence, int n)
    {
        return sentence
            .Split(" ")
            .Aggregate(
                new List<String> { "" },
                (rows, word) =>
                {
                    var lastRow = rows.Last();
                    if (lastRow.Length + 1 + word.Length <= n)
                    {
                        lastRow += " " + word;
                        rows[^1] = lastRow.Trim();
                    }
                    else
                    {
                        if (word.Length <= n)
                        {
                            rows.Add(word);
                        }
                        else
                        {
                            throw new ArgumentException($"Word {word} is too long. Max lenght is ${n}!");
                        }
                    }

                    return rows;
                }
            );
    }
}