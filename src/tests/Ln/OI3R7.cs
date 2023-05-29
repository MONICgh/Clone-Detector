
namespace RainWater;

public class RainWater
{
    private List<int> Heights { get; set; }
    private int InitHeightsSum { get; }
    public RainWater(List<int> heights)
    {
        InitHeightsSum = heights.Sum();
        Heights = heights;
    }

    private int MaxHeight()
    {
        return Heights.Max();
    }

    public int CalculateCapacity()
    {
        int direction = 1;
        for (int i = 1; i < Heights.Count; i++)
        {
            if (direction == 1)
            {
                if (Heights[i] < Heights[i - 1])
                {
                    Heights[i] = Heights[i - 1];
                }
            }
            else
            {
                if (Heights[i] > Heights[i - 1])
                {
                    Heights[i - 1] = Heights[i];
                }
            }
            
            if (Heights[i] == MaxHeight())
            {
                direction = -1;
            }
        }

        return Heights.Sum() - InitHeightsSum;
    }
}