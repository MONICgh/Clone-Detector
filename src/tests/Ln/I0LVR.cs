namespace Task4;

public class Dices
{
    public static int CountChance(int dicesNumber, int requiredSum)
    {
        if (dicesNumber == 0)
        {
            return requiredSum == 0 ? 1 : 0;
        }

        if (requiredSum <= 0)
        {
            return 0;
        }
        
        var result = 0;
        for (var i = 1; i <= 6; i++)
        {
            result += CountChance(dicesNumber - 1, requiredSum - i);
        }

        return result;
    }
}
