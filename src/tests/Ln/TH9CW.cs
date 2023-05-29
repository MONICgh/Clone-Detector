using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace HW02.DropTheDice
{
    public class DiceDropper
    {
        private readonly IDictionary<Tuple<int, int>, int> _savedData = new Dictionary<Tuple<int, int>, int>();
        private int RecursiveDiceRoll(int diceCount, int expectedSum)
        {
            if (expectedSum < diceCount || expectedSum > 6 * diceCount)
                return 0;
            if (expectedSum == 0)
                return 1;
            var funcTuple = new Tuple<int, int>(expectedSum, diceCount);
            if (_savedData.ContainsKey(funcTuple))
                return _savedData[funcTuple];
            _savedData[funcTuple] = 0;
            for (var i = 1; i <= Math.Min(expectedSum, 6); i++)
            {
                _savedData[funcTuple] += RecursiveDiceRoll(diceCount - 1, expectedSum - i );
            }
            return _savedData[funcTuple];
        }

        public int DiceRoll(int diceCount, int expectedSum) => RecursiveDiceRoll(diceCount, expectedSum);
    }

}
