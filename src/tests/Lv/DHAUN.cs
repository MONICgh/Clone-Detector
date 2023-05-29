using System.Text;

namespace HW_07;

public abstract class Named
{
    protected bool Equals(Named other)
    {
        return Name == other.Name;
    }
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj))
            return false;
        if (ReferenceEquals(this, obj))
            return true;
        return obj.GetType() == GetType() && Equals((Named)obj);
    }
    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
    public string Name = "";
}

public static class LinqClass
{
    public static string Concatenate(IEnumerable<Named> data, char delimiter = ' ')
    {
        return data.Skip(3).Aggregate("", (s, named) =>
        {
            if (s.Length == 0)
                return named.Name;
            return s + delimiter + named.Name;
        });
    }

    public static IEnumerable<Named> GetPosBiggerThanLength(IEnumerable<Named> data) =>
        data.Select(
                (value, index) => new { value, index })
            .Where(arg => arg.value.Name.Length > arg.index)
            .Select(arg => arg.value);


    public static string RebuildSentence(string s)
    {
        var groups =
            s.Split(" ")
                .Select(word => word.Where(c => !char.IsPunctuation(c)))
                .GroupBy(charSeq => charSeq.Count()).Select(grouping => new
                {
                    Length = grouping.Key,
                    Data = grouping.ToList()
                }).OrderByDescending(data => data.Length);
        return groups.Aggregate("",
            (current1, group) =>
                group.Data.Aggregate(current1 + "Length: " + group.Length + " | " + "Count: " + group.Data.Count + "\n",
                    (current, enumerable) =>
                        current + new string(enumerable.ToArray()) + "\n")
                + "\n"
        );
    }


    public static string TranslateLinq(Dictionary<String, String> dict, IEnumerable<String> sentence, int maxPageSize)
    {
        var translated = sentence.Select(notTranslated => dict[notTranslated]);
        var enumerable = translated.Select((x, i) => new { Index = i, Value = x })
            .GroupBy(x => x.Index / maxPageSize)
            .Select(x => x.Select(v => v.Value.ToUpper()).ToList());
        return enumerable.Aggregate("", (current, list1) => current + list1.Aggregate((s, ls) => s + " " + ls + "\n"));
    }
    public static List<string> BucketSeparator(string word, int bucketLength)
    {
        int lengthOfSequence(String s)
        {
            bool started = false;
            var len = 0;
            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] != ' ')
                {
                    started = true;
                    len++;
                }
                else
                {
                    if (i <= 0 || s[i - 1] != ' ')
                    {
                        if (started)
                            len++;
                    }
                }
            }
            return len;
        }

        word = word.TrimEnd().Insert(word.Length, " ").TrimStart();

        int pos(int i)
        {
            int prevPos = i;
            for (int j = i; j < word.Length - 1; j++)
            {
                if (word[j] == ' ' || word[j + 1] != ' ')
                    continue;
                var substr = word.Substring(i, j - i + 1);
                if (lengthOfSequence(substr) <= bucketLength)
                {
                    prevPos = j;
                }
                else
                {
                    return prevPos;
                }
            }
            return prevPos;
        }

        if (word.Split(" ").Any(s => s.Length > bucketLength))
        {
            return new List<string>();
        }
        var answer = new List<string>();
        for (int i = 0; i < word.Length; i++)
        {
            if (word[i] == ' ')
            {
                continue;
            }
            int ans = pos(i);
            answer.Add(word.Substring(i, ans - i + 1));
            i = ans;
        }
        return answer;
    }
}
