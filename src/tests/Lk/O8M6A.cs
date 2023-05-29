using System;

namespace HamsterSort;

public class Wool: IComparable
{
    public int color;
    public String type;

    public Wool(int color, string type)
    {
        this.color = color;
        this.type = type;
    }

    public override string ToString()
    {
        return $"Wool(color=#{Convert.ToString(color, 16)}, type={type})";
    }

    public int CompareTo(object? obj)
    {
        if (obj is Wool wool)
        {
            if (color < wool.color)
            {
                return -1;
            }
            return color > wool.color ? 1 : String.CompareOrdinal(type, wool.type);
        }
        throw new ArgumentException($"Incorrect argument: {obj}");
    }
}

public class Hamster : IComparable
{
    public Wool Wool;
    public readonly int Weight;
    public readonly int Height;
    public readonly int Age;

    public Hamster(Wool wool, int weight, int height, int age)
    {
        Wool = wool;
        Weight = weight;
        Height = height;
        Age = age;
    }
    public override string ToString()
    {
        return $"Hamster(\n\tWool={Wool},\n\tWeight={Weight},\n\tHeight={Height},\n\tAge={Age}\n)";
    }

    public static bool operator ==(Hamster h1, Hamster h2)
    {
        return h1.CompareTo(h2) == 0;
    }

    public static bool operator !=(Hamster h1, Hamster h2)
    {
        return !(h1 == h2);
    }
    
    public static bool operator <(Hamster h1, Hamster h2)
    {
        return h1.CompareTo(h2) < 0;
    }

    public static bool operator >(Hamster h1, Hamster h2)
    {
        return h1.CompareTo(h2) > 0;
    }

    public int CompareTo(object? obj)
    {
        if (obj is Hamster hamster)
        {
            int woolCompare = Wool.CompareTo(hamster.Wool);
            if (woolCompare == 0)
            {
                int weightCompare = Weight - hamster.Weight;
                if (weightCompare == 0)
                {
                    int heightCompare = Height - hamster.Height;
                    if (heightCompare == 0)
                    {
                        return Age - hamster.Age;
                    }

                    return heightCompare;
                }

                return weightCompare;
            }

            return woolCompare;
        }
        throw new ArgumentException($"Incorrect argument: {obj}");
    }
}