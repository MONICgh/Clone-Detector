namespace GroupWord
{
    public static class GroupWord
    {
        public static string Group(string sentence)
        {
            return
                sentence.ToLower().Split(new char[] { '.', ',', '?', '!', ':', ';', '-', '[', ']', '{', '}',
                '<', '>', '(', ')', '\'', '"', ' '}, StringSplitOptions.RemoveEmptyEntries)
                .GroupBy(s => s.Length)
                .OrderByDescending(group => group.Count())
                .Aggregate(("", 1), (total, curGroup) => (string.Format("{0}Группа {1}. Длина {2}. Количество {3}\n{4}\n",
                    total.Item1, total.Item2, curGroup.Key, curGroup.Count(),
                    curGroup.Aggregate("", (totalWord, s) => totalWord + s + "\n")), total.Item2 + 1)).Item1;
        }
    }
}