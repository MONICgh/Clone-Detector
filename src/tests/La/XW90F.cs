namespace EnvelopesTask;

public class Envelope : IComparable
{
    public int Height;
    public int Width;
    
    public Envelope(int height, int width)
    {
        Height = height;
        Width = width;
    }

    private int Metric()
    {
        return Math.Max(Height, Width);
    }

    public int CompareTo(object? obj)
    {
        if (obj is Envelope envelope)
        {
            return Metric() - envelope.Metric();
        }
        throw new Exception($"Invalid argument {obj}");
    }

    public bool Covers(Envelope? envelope)
    {
        if (envelope == null)
        {
            return true;
        }

        return (Height > envelope.Height && Width > envelope.Width) ||
               (Width > envelope.Height && Height > envelope.Width);
    }
}

public class Solution
{
    public static int FindSolution(List<Envelope> envelopes)
    {
        envelopes.Sort();
        var dp = new List<Tuple<int, Envelope?>>(envelopes.Count + 1) { new (0, null) };

        foreach (var envelope in envelopes)
        {
            var envelope1 = envelope;
            var theBestCovered = dp
                .Where(x => envelope1.Covers(x.Item2))
                .MaxBy(x => x.Item1);
            var theBestUncovered = dp
                .MaxBy(x => x.Item1);

            if (theBestCovered != null && theBestCovered.Item1 + 1 > theBestUncovered.Item1)
            {
                dp.Add(new(theBestCovered.Item1 + 1, envelope));
            }
            else
            {
                dp.Add(theBestUncovered);
            }
        }

        return dp.Last().Item1;
    }
}