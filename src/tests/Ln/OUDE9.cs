namespace Dice
{
    public class Dice
    {
        private static int recursiveCombinations(int diceCnt, int sum)
        {
            if (diceCnt == 1)
            {
                if (1 <= sum && sum <= 6)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            int combCnt = 0;
            for (int i = 1; i <= 6; i++)
            {
                combCnt += recursiveCombinations(diceCnt - 1, sum - i);
            }
            return combCnt;
        }
        public static int Combinations(int diceCnt, int sum)
        {
            if (diceCnt < 1)
            {
                return 0;
            }
            return recursiveCombinations(diceCnt, sum);
        }
    }
}