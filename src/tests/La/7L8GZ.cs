int NestedEnvelopes(List<(int, int)> envelopes)
{
    if (envelopes.Count == 0)
        return 0;
    
    envelopes = envelopes.Select(pair =>
    {
        if (pair.Item1 > pair.Item2)
            return (pair.Item2, pair.Item1);
        return pair;
    }).ToList();
    envelopes.Sort((pair1, pair2) => pair1.Item1.CompareTo(pair2.Item1));

    var maxNestedEnvelopesCnt = new List<int>();

    for (var i = 0; i < envelopes.Count; i++)
    {
        maxNestedEnvelopesCnt.Add(1);
        for (var j = 0; j < i; j++)
        {
            if (envelopes[i].Item1 > envelopes[j].Item1 && envelopes[i].Item2 > envelopes[j].Item2)
            {
                if (maxNestedEnvelopesCnt[j] + 1 > maxNestedEnvelopesCnt[i])
                    maxNestedEnvelopesCnt[i] = maxNestedEnvelopesCnt[j] + 1;
            }
        }
    }
    
    return maxNestedEnvelopesCnt.Max();
}

Console.WriteLine(NestedEnvelopes(new List<(int, int)>
{
    (5, 4), (6, 4), (6, 7), (2, 3)
}));
Console.WriteLine(NestedEnvelopes(new List<(int, int)>
{
    (1, 1), (1, 1), (1, 1)
}));