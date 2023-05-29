namespace HW_04.HorseCar;

public enum CarType
{
    Truck,
    RacingCar,
    Small,
}

internal static class TypeConverter
{
    public static CarType ConvertType(HorseType horseType)
    {
        var result = horseType switch
        {
            HorseType.Pony => CarType.Small,
            HorseType.FastHorse => CarType.RacingCar,
            HorseType.Heavy => CarType.Truck,
            _ => throw new Exception()
        };

        return result;
    }
}

public class Car
{
    private bool Equals(Car other)
    {
        return Type == other.Type && IsStudded == other.IsStudded && Age == other.Age && Weight == other.Weight && MaxSpeed == other.MaxSpeed;
    }
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj))
            return false;
        if (ReferenceEquals(this, obj))
            return true;
        if (obj.GetType() != this.GetType())
            return false;
        return Equals((Car)obj);
    }
    public override int GetHashCode()
    {
        return HashCode.Combine((int)Type, IsStudded, Age, Weight, MaxSpeed);
    }
    public readonly CarType Type;
    public readonly bool IsStudded;

    public readonly int Age;
    public readonly int Weight;

    public readonly int MaxSpeed;

    public Car(CarType type, bool isStudded, int age, int weight, int maxSpeed)
    {
        Type = type;
        IsStudded = isStudded;
        Age = age;
        Weight = weight;
        MaxSpeed = maxSpeed;
    }
    public override string ToString()
    {
        return $"{Type} {Weight} {Age} {IsStudded} {MaxSpeed}";
    }

    public static bool operator ==(Car c1, Car c2)
    {
        return c1.Age == c2.Age && c1.Weight == c2.Weight;
    }

    public static bool operator !=(Car c1, Car c2)
    {
        return !(c1 == c2);
    }

    private Car(Horse horse)
    {
        Type = TypeConverter.ConvertType(horse.Type);
        IsStudded = horse.IsShod;
        Age = horse.Age;
        Weight = horse.Weight;
        MaxSpeed = horse.MaxSpeed;
    }

    public static explicit operator Car(Horse horse)
    {
        return new Car(horse);
    }

}
