namespace HW_04.HorseCar;

public enum HorseType
{
    Heavy,
    FastHorse,
    Pony,
}

public class Horse
{
    protected bool Equals(Horse other)
    {
        return Type == other.Type && IsShod == other.IsShod && Age == other.Age && Weight == other.Weight && MaxSpeed == other.MaxSpeed;
    }
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj))
            return false;
        if (ReferenceEquals(this, obj))
            return true;
        if (obj.GetType() != this.GetType())
            return false;
        return Equals((Horse)obj);
    }
    public override int GetHashCode()
    {
        return HashCode.Combine((int)Type, IsShod, Age, Weight, MaxSpeed);
    }
    public readonly HorseType Type;
    public readonly bool IsShod;
    public readonly int Age;
    public readonly int Weight;
    public readonly int MaxSpeed;

    public Horse(HorseType type, bool isShod, int age, int weight, int maxSpeed)
    {
        Type = type;
        IsShod = isShod;
        Age = age;
        Weight = weight;
        MaxSpeed = maxSpeed;
    }

    public static bool operator ==(Horse h1, Horse h2)
    {
        return h1.Age == h2.Age && h1.Weight == h2.Weight;
    }

    public static bool operator !=(Horse h1, Horse h2)
    {
        return !(h1 == h2);
    }

    public static bool operator <(Horse h1, Horse h2)
    {
        if (h1.Age != h2.Age)
            return h1.Age < h2.Age;
        if (h1.Weight != h2.Weight)
            return h1.Weight < h2.Weight;
        return h1.MaxSpeed < h2.MaxSpeed;
    }

    public static bool operator >(Horse h1, Horse h2)
    {
        return h2 < h1;
    }
}
