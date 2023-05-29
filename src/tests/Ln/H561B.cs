using System;
using System.Collections.Generic;
using System.Text;

namespace CSDotNet.Lab2
{
    public class RollDice
    {
        public int diceRoll(int die, int res)
        {
            if (res < die)
                return 0;
            if (die == 1)
            {
                if (res > 6)
                    return 0;
                return 1;
            }

            int sum = 0;

            for (int i = 1; i <= 6; ++i)
            {
                sum += diceRoll(die - 1, res - i);
            }
            return sum;
        }
    }
}
