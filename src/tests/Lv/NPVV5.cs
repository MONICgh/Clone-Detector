string Statistics(string sentence)
{
    sentence = string.Join("", sentence.Where(c => char.IsWhiteSpace(c) || char.IsLetterOrDigit(c)));
    var wordLists = sentence.Split()
        .Where(word => word.Length != 0)
        .Select(word => word.ToLower())
        .GroupBy(word => word.Length)
        .Select(wordGroup => wordGroup.ToList())
        .OrderByDescending(wordList => wordList.Count);

    return string.Join("\n\n",
        wordLists.Select((wordList, index) => 
                $"Группа {index + 1}. Длина {wordList.First().Length}. Количество {wordList.Count}\n" + string.Join("\n", wordList)
            )
    );
}

var sentence = "Это что же получается: ходишь, ходишь в школу, а потом бац - вторая смена";
Console.WriteLine(Statistics(sentence));