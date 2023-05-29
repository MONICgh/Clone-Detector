namespace ClassAttributes;

[Custom("Joe", 2, "Class to work with health data.", "Arnold", "Bernard")]
public class HealthScore
{
    [Custom("Andrew", 3, "Method to collect health data.", "Sam", "Alex")]
    public static long CalcScoreData()
    {
        return new Random().Next() % 100;
    }

    public static long FooWithoutAttr()
    {
        return 0;
    }
    
    [Custom("Jake", 1, "Method to calculate something", "Sam", "John", "Hao")]
    public static long CalcSomething()
    {
        return 1;
    }
} 
