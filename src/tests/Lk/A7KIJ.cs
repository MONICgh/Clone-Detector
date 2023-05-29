using System.Diagnostics;
using HW_04.HorseCar;

namespace HW_04.Hamsters;

public enum WoolType
{
    Good,
    Normal,
    Perfect,
}

public enum WoolColor
{
    Gold,
    SemiGold,
    Usual,
}

public class Hamster
{
    public Hamster(int height, int weight, WoolColor woolColor, WoolType woolType, int ageMonths)
    {
        Height = height;
        Weight = weight;
        WoolColor = woolColor;
        WoolType = woolType;
        AgeMonths = ageMonths;
    }
    public WoolColor WoolColor { get; }
    public WoolType WoolType { get; }
    public int Weight { get; }
    public int Height { get; }

    public int AgeMonths { get; }

    public int GetHamsterValue()
    {
        var woolColorCoefficient = WoolColor switch
        {
            WoolColor.Gold => 5,
            WoolColor.SemiGold => 3,
            WoolColor.Usual => 1,
            _ => throw new ArgumentException("Unknown wool color")
        };

        var woolTypeCoefficient = WoolType switch
        {
            WoolType.Good => 2,
            WoolType.Normal => 3,
            WoolType.Perfect => 7,
            _ => throw new ArgumentException("Unknown wool type")
        };

        // Some of them can live around 7 years
        var ageCoefficient = Math.Max(7 * 12 - AgeMonths, 0);

        return ageCoefficient * woolColorCoefficient * woolTypeCoefficient * Height * Weight;
    }

    public static bool operator <(Hamster h1, Hamster h2)
    {
        return h1.GetHamsterValue() < h2.GetHamsterValue();
    }

    public static bool operator >(Hamster h1, Hamster h2)
    {
        return h2 < h1;
    }

}

public static class RandomHamsterCreator
{
    private static Random random = new Random();

    public static void SetSeed(int seed)
    {
        random = new Random(Seed: seed);
    }
    public static Hamster getRandom()
    {
        return new Hamster(random.Next(1, 15),
            random.Next(1, 100),
            randomWoolColor(),
            randomWoolType(),
            random.Next(1, 7 * 12 + 2));
    }

    private static WoolType randomWoolType()
    {
        var value = random.Next(1, 11);
        return value switch
        {
            >= 10 => WoolType.Perfect,
            >= 8 => WoolType.Good,
            _ => WoolType.Normal
        };
    }

    private static WoolColor randomWoolColor()
    {
        var value = random.Next(1, 11);
        return value switch
        {
            >= 10 => WoolColor.Gold,
            >= 8 => WoolColor.SemiGold,
            _ => WoolColor.Usual
        };
    }

}

public static class HamsterSorter
{
    public static void SortHamsterList(List<Hamster> hamsters)
    {
        for (var i = 0; i < hamsters.Count; i++)
        {
            for (var j = 0; j + 1 < hamsters.Count; j++)
            {
                if (hamsters[j] < hamsters[j + 1])
                {
                    (hamsters[j], hamsters[j + 1]) = (hamsters[j + 1], hamsters[j]);
                }
            }
        } 
        // I decided to write bubble sort in order to show how it works here.
    }
}
