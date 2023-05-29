using System;
using System.Collections.Generic;
using System.Text;

namespace RacingCar
{
    public class ShortestWay
    {
        private int _purpose;

        public ShortestWay(int purpose)
        {
            _purpose = purpose;
        }

        public string GetShortestWay()
        {
            var currentLength = 1;
            while (true)
            {
                var sequences = GetMotionSequences(currentLength);
                foreach (var sequence in sequences)
                {
                    if (GetEndPosition(sequence) == _purpose)
                    {
                        return sequence;
                    }
                }

                currentLength += 1;
            }
        }

        private int GetEndPosition(string way)
        {
            var racingCar = new RacingCar();
            foreach (var step in way)
            {
                if (step == 'A')
                {
                    racingCar.DoA();
                }
                else if (step == 'R')
                {
                    racingCar.DoR();
                }
            }

            return racingCar.Position;
        }

        private List<string> GetMotionSequences(int length)
        {
            var answer = new List<string>();
            int numberOfSequences = (int)Math.Pow(2, length);

            for (int i = 0; i < numberOfSequences; i++)
            {
                var sequence = Convert.ToString(i, 2);
                sequence = sequence.PadLeft(length, '0').Replace('0', 'A').Replace('1', 'R');
                answer.Add(sequence);
            }

            return answer;
        }
    }
}