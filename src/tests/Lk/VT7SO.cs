using System.Collections.Generic;

namespace HamsterSort;

public static class HamsterSort
{
    public static List<Hamster> SortHambsterList(List<Hamster> hamsters)
    {
        for (int currentIndex = 0; currentIndex < hamsters.Count; currentIndex++)
        {
            for (int i = currentIndex; i < hamsters.Count; i++)
            {
                if (hamsters[currentIndex].CompareTo(hamsters[i]) > 0)
                {
                    (hamsters[currentIndex], hamsters[i]) = (hamsters[i], hamsters[currentIndex]);
                }
            }
        }

        return hamsters;
    }
}