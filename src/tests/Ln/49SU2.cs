namespace Dice;

public static class Dice
{
    public static int DigitSum(int x, int count)
    {
        int digit = 0;
        var digits = new List<int>();
        while (digit < count)
        {
            int digitValue = 1 + (int)(x / Math.Pow(6, digit)) % 6;
            digits.Add(digitValue);
            digit++;
        }

        return digits.Sum();
    }
    public static int DiceRoll(int count, int sum)
    {
        if (sum < count || sum > 6 * count)
        {
            return 0;
        }
        
        int result = 0;
        int currentCombination = 0;
        while (currentCombination < Math.Pow(6, count))
        {
            if (DigitSum(currentCombination, count) == sum)
            {
                result++;
            }

            currentCombination++;
        }

        return result;
    }
}