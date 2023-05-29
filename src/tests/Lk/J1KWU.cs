using System;

namespace TransformationOperator;

public enum HorseType
{
    HeavyTruck,
    RaceHorse,
    Riding,
    Pony,
}

public class Horse
{
    public HorseType type;
    public bool shod;
    public int age;
    public String name;
    public int height;
    public int weight;
    public int maxSpeed;

    public Horse(HorseType type, bool shod, int age, string name, int height, int weight, int maxSpeed)
    {
        this.type = type;
        this.shod = shod;
        this.age = age;
        this.name = name;
        this.height = height;
        this.weight = weight;
        this.maxSpeed = maxSpeed;
    }

    public static bool operator ==(Horse h1, Horse h2)
    {
        return h1.age == h2.age && h1.height == h2.height && h1.weight == h2.weight;
    }

    public static bool operator !=(Horse h1, Horse h2)
    {
        return !(h1 == h2);
    }

    public static bool operator <(Horse h1, Horse h2)
    {
        if (h1.age < h2.age)
        {
            return true;
        }

        if (h1.age == h2.age)
        {
            if (h1.height < h2.height)
            {
                return true;
            }

            if (h1.height == h2.height)
            {
                if (h1.weight < h2.weight)
                {
                    return true;
                }
            }
        }

        return false;
    }

    public static bool operator >(Horse h1, Horse h2)
    {
        if (h1.age > h2.age)
        {
            return true;
        }

        if (h1.age == h2.age)
        {
            if (h1.height > h2.height)
            {
                return true;
            }

            if (h1.height == h2.height)
            {
                if (h1.weight > h2.weight)
                {
                    return true;
                }
            }
        }

        return false;
    }
}
