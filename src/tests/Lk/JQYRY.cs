public class Hamster : IComparable
{
    private readonly int _furColor;
    private readonly int _furType;
    private readonly double _weight;
    private readonly double _height;
    private readonly int _age;

    Hamster(int furColor, int furType, double weight, double height, int age)
    {
        _furColor = furColor;
        _furType = furType;
        _weight = weight;
        _height = height;
        _age = age;
    }

    public static Hamster Random()
    {
        var random = new Random();

        int RandInt(int b)
        {
            return random.Next(b);
        }

        double RandDouble(double b, int pr)
        {
            return Math.Round(random.NextDouble() * b, pr);
        }

        return new Hamster(
            furColor: RandInt(5),
            furType: RandInt(3),
            weight: RandDouble(200.0, 2),
            height: RandDouble(10.0, 2),
            age: RandInt(36));
    }

    public int CompareTo(object? obj)
    {
        if (obj is not Hamster other)
        {
            return -1;
        }

        if (_age != other._age)
        {
            return _age - other._age;
        }

        int MeasureVal(double h, double w)
        {
            return (int)(h * 10 + w);
        }

        if (MeasureVal(_height, _weight) != MeasureVal(other._height, other._weight))
        {
            return -(MeasureVal(_height, _weight) - MeasureVal(other._height, other._weight));
        }

        int FurVal(int c, int t)
        {
            return c * t;
        }

        return -(FurVal(_furColor, _furType) - FurVal(other._furColor, other._furType));
    }

    public override string ToString()
    {
        return String.Format("Hamster(age: {0}, height: {1}, weight: {2}, furColor: {3}, furType: {4})",
            _age,
            _height,
            _weight,
            _furColor,
            _furType);
    }
}