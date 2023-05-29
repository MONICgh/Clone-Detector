using System.Diagnostics;
using Task3;

int MaxEnvelopers(List<Enveloper> envelopers)
{
    envelopers.Sort((e1, e2) => e1.CompareTo(e2));
    var maxNumberFinishedInElement = new int [envelopers.Count];
    for (var i = 0; i < envelopers.Count; i++)
    {
        maxNumberFinishedInElement[i] = 1;
        for (var j = 0; j < i; j++)
        {
            if (envelopers[j].Max < envelopers[i].Max && envelopers[j].Min < envelopers[i].Min)
            {
                maxNumberFinishedInElement[i] =
                    Math.Max(maxNumberFinishedInElement[i], maxNumberFinishedInElement[j] + 1);
            }
        }
    }

    return maxNumberFinishedInElement.Max();
} 

Debug.Assert(MaxEnvelopers(new List<Enveloper> { new (5, 4), new (6, 4), new (6, 7), new (2, 3) }) == 3);
Debug.Assert(MaxEnvelopers(new List<Enveloper> { new (1, 1), new (1, 1), new (1, 1)} ) == 1);

Console.WriteLine("All is Okay!");