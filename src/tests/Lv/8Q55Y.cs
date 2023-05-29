using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace Application
{
    class Task5
    {
        static List<string> bucketize(string sentence, int maxSize)
        {
            sentence = sentence.Trim();
            var matches = Regex.Matches(sentence, @"(^|\s)\S").Select(n => n.Index + 1).ToList();    // indexes start words
            matches[0] -= 1;
            var segmentsWithIndexes = Regex.Matches(sentence, @"\S(\s|$)")
                .Select(n => n.Index + 1)
                .Aggregate(new { segments = new List<string>(), matchesIndex = 0, indexBefore = 0 }, (acc, index) =>
                {
                    if (acc.matchesIndex == -1)  // marker not success
                    {
                        return acc;
                    }
                    else
                    {
                        var startIndex = matches[acc.matchesIndex];
                        if (index - startIndex > maxSize)
                        {
                            if (acc.indexBefore - startIndex > maxSize)
                            {
                                return new { segments = new List<string>(), matchesIndex = -1, indexBefore = -1 };
                            }
                            else
                            {
                                acc.segments.Add(sentence.Substring(startIndex, acc.indexBefore - startIndex));
                                var newMatchesIndex = acc.matchesIndex;
                                while (matches[newMatchesIndex] < acc.indexBefore)
                                {
                                    newMatchesIndex++;
                                }
                                return new { segments = acc.segments, matchesIndex = newMatchesIndex, indexBefore = index };
                            }
                        }
                        else
                        {
                            return new { segments = acc.segments, matchesIndex = acc.matchesIndex, indexBefore = index };
                        }
                    }
                });
            if (segmentsWithIndexes.matchesIndex == -1 || segmentsWithIndexes.indexBefore - matches[segmentsWithIndexes.matchesIndex] > maxSize)
            {
                return new List<string>();
            }
            var startIndex = matches[segmentsWithIndexes.matchesIndex];
            var segments = segmentsWithIndexes.segments;
            segments.Add(sentence.Substring(startIndex, segmentsWithIndexes.indexBefore - startIndex));     // add last
            return segments;
        }

        static void Main()
        {
            var tests = new List<Tuple<string, int>>() {
                Tuple.Create("она продает морские раковины у моря", 16),
                Tuple.Create("мышь прыгнула через сыр", 8),
                Tuple.Create("волшебная пыль покрыла воздух", 15),
                Tuple.Create("a b c d e ", 2),
                Tuple.Create("aa b", 1),
            };

            foreach (Tuple<string, int> test in tests)
            {
                Console.WriteLine(string.Join("\n", bucketize(test.Item1, test.Item2)));
                Console.WriteLine("--------------------");
            }
        }
    }
}
