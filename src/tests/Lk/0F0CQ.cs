using System;

namespace TransformationOperator;

public enum CarType
{
    Pickup,
    Racing,
    Crossover,
    Mini,
}

static class TypeConverter
{
    public static CarType ConvertType(HorseType horseType)
    {
        CarType result;
        switch (horseType)
        {
            case HorseType.Pony:
                result = CarType.Mini;
                break;
            case HorseType.Riding:
                result = CarType.Crossover;
                break;
            case HorseType.RaceHorse:
                result = CarType.Racing;
                break;
            case HorseType.HeavyTruck:
                result = CarType.Pickup;
                break;
            default:
                result = CarType.Crossover;
                break;
        }

        return result;
    }
}

public class Car
{
    private CarType type;
    private bool studded;

    private int age;
    private String mark;
    private int height;
    private int weight;

    private int maxSpeed;

    public Car(CarType type, bool studded, int age, string mark, int height, int weight, int maxSpeed)
    {
        this.type = type;
        this.studded = studded;
        this.age = age;
        this.mark = mark;
        this.height = height;
        this.weight = weight;
        this.maxSpeed = maxSpeed;
    }
    
    public static bool operator ==(Car c1, Car c2)
    {
        return c1.age == c2.age && c1.height == c2.height && c1.weight == c2.weight;
    }

    public static bool operator !=(Car c1, Car c2)
    {
        return !(c1 == c2);
    }

    private Car(Horse horse)
    {
        type = TypeConverter.ConvertType(horse.type);
        studded = horse.shod;
        age = horse.age;
        mark = horse.name;
        height = horse.height;
        weight = horse.weight;
        maxSpeed = horse.maxSpeed;
    }

    // Uncomment this operator and comment the next to run the first test
    // public static implicit operator Car(Horse horse)
    // {
    //     return new Car(horse);
    // }
    
    public static explicit operator Car(Horse horse)
    {
        return new Car(horse);
    }
    
}