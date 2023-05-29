namespace Task2;

[Custom("Joe", 2, "Class to work with health data.", "Arnold", "Bernard")]
public class HealthScore
{
    [Custom("Andrew", 3, "Method to collect health data.", "Sam", "Alex")]
    public static long CalcScoreData()
    {
        return new Random().NextInt64();
    }

    public static string MethodWithoutCustomAttribute()
    {
        return "No custom attribute here";
    }
} 
