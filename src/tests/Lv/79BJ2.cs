using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab_7_Task_4
{
    public class Task4
    {
        private readonly IDictionary<string, string> Dictionary;

        public Task4(IDictionary<string, string> dictionary)
        {
            Dictionary = new Dictionary<string, string>(dictionary);
        }

        public string[] GetBook(string text, int numberOfWords)
        {
            var translatedWords = Translate(StripPunctuation(text).Split(' '));

            return translatedWords
                .Select((x, i) => (Word: x, Index: i))
                .GroupBy(
                    x => x.Index / numberOfWords,
                    x => x.Word,
                    (key, words) => string.Join(" ", words))
                .ToArray();
        }
        
        private string StripPunctuation(string s)
        {
            var sb = new StringBuilder();
            foreach (char c in s)
            {
                if (!char.IsPunctuation(c))
                    sb.Append(c);
            }
            return sb.ToString();
        }

        private string[] Translate(string[] words)
        {
            for (var i = 0; i < words.Length; i++)
            {
                words[i] = Dictionary[words[i].ToLower()].ToUpper();
            }

            return words;
        }
    }
}