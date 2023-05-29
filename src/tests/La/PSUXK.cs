namespace CustomAttributeTask;

[Custom("Joe", 2, "Class to work with health data.", "Arnold", "Bernard")]
public class HealthScore
{
    [Custom("Andrew", 3, "Method to collect health data.", "Sam", "Alex")]
    public static long CalcScoreData()
    {
        return 100;
    }

    public static long CalcScoreDataWithoutAttributes()
    {
        return 0;
    }
}
