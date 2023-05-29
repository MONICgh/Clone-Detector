
namespace RainWater;

public static class RainWaterTest
{
    public static void Main()
    {
        var rainWater = new RainWater(
            new List<int>() { 6,5,4,3,2,1 }
        );
        Console.WriteLine(rainWater.CalculateCapacity());
        //Assert.Equal(6, rainWater.CalculateCapacity());
    }
    
}