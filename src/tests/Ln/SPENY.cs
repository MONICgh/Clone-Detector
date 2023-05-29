namespace DiceRoll;

public class DiceRoll
{
    private Dictionary<(int, int), int> counted = new Dictionary<(int, int), int>();

    public int diceRoll(int diceCnt, int result)
    {
        if (counted.ContainsKey((diceCnt, result)))
        {
            return counted[(diceCnt, result)];
        }

        if (diceCnt == 1)
        {
            if (result >= 1 && result <= 6)
            {
                counted[(diceCnt, result)] = 1;
                return 1;
            }

            counted[(diceCnt, result)] = 0;
            return 0;
        }

        int totalCnt = 0;
        for (int i = 1; i <= 6; i++)
        {
            totalCnt += diceRoll(diceCnt - 1, result - i);
        }

        return totalCnt;
    }
}