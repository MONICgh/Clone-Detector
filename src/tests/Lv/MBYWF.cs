using System.Diagnostics;

IEnumerable<string> Bucketize(string text, int n)
{
    var words = text.Split(" ").Where(word => word.Length > 0);
    var buckets = new List<string>();
    string curBucket = "";
    
    foreach (var word in words)
    {
        if (word.Length > n)
        {
            return new List<string>();
        }

        if (curBucket.Length == 0)
        {
            curBucket += word;
        }
        else
        {
            if (curBucket.Length + 1 + word.Length > n)
            {
                buckets.Add(curBucket);
                curBucket = word;
            }
            else
            {
                curBucket += " " + word;
            }
        }
    }

    if (curBucket.Length > 0)
    {
        buckets.Add(curBucket);
    }

    return buckets;
}

Debug.Assert(Bucketize("она продает морские раковины у моря", 16).Aggregate((acc, t) => acc + ";" + t)
    .Equals("она продает;морские раковины;у моря"));

Debug.Assert(Bucketize("мышь прыгнула через сыр", 8).Aggregate((acc, t) => acc + ";" + t)
    .Equals("мышь;прыгнула;через;сыр"));
    
Debug.Assert(Bucketize("волшебная пыль покрыла воздух", 15).Aggregate((acc, t) => acc + ";" + t)
    .Equals("волшебная пыль;покрыла воздух"));
    
Debug.Assert(Bucketize("a b  c d e", 2).Aggregate((acc, t) => acc + ";" + t)
    .Equals("a;b;c;d;e"));
    
Debug.Assert(!Bucketize("abc abcd", 3).Any());

Console.WriteLine("All is Okay!");