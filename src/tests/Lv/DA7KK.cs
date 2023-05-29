using System;
using System.Linq;

// наверное уже было проще полный перебор написать...
// но я так долго это писала, так что пусть будет это решение

namespace Lab_7_MaxMinTask
{
    public class MaxMinTask
    {
        public long[] DoMaxMinTask(long number)
        {
            if (number == 0)
                return new long[] {0, 0};
            
            var parsedNumber = number.ToString();
            var reversedParsedNumber = String.Copy(parsedNumber).ToCharArray();
            Array.Reverse(reversedParsedNumber);

            var maxValue = parsedNumber.Max();
            var minValue = parsedNumber.Replace("0", String.Empty).Min();

            var indexForLastMax = reversedParsedNumber.Length - 1 - Array.IndexOf(reversedParsedNumber, maxValue);
            var indexForLastMin = reversedParsedNumber.Length - 1 - Array.IndexOf(reversedParsedNumber, minValue);

            var indexForFirstNotMaxOrMax = GetFirstIndexNotMaxOrMax(parsedNumber, maxValue, indexForLastMax);
            var indexForFirstNotMinOrMin = GetFirstIndexNotMinOrMin(parsedNumber, minValue, indexForLastMin);

            if (indexForFirstNotMinOrMin == indexForLastMin && parsedNumber.Min() == '0')
            {
                indexForLastMin = reversedParsedNumber.Length - 1 - Array.IndexOf(reversedParsedNumber, '0');
                indexForFirstNotMinOrMin = GetFirstIndexNotZero(parsedNumber, indexForLastMin);
            }

            var answerMax = String.Copy(parsedNumber).ToCharArray();
            var answerMin = String.Copy(parsedNumber).ToCharArray();

            (answerMax[indexForFirstNotMaxOrMax], answerMax[indexForLastMax]) = (answerMax[indexForLastMax], answerMax[indexForFirstNotMaxOrMax]);
            (answerMin[indexForFirstNotMinOrMin], answerMin[indexForLastMin]) = (answerMin[indexForLastMin], answerMin[indexForFirstNotMinOrMin]);

            return new long[] { long.Parse(answerMax), long.Parse(answerMin) };
        }

        private int GetFirstIndexNotMaxOrMax(string s, char max, int indexForLastMax)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (i == indexForLastMax)
                {
                    return indexForLastMax;
                }
                
                if (s[i] != max)
                {
                    return i;
                }
            }

            return indexForLastMax;
        }
        
        private int GetFirstIndexNotMinOrMin(string s, char min, int indexForLastMin)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (i == indexForLastMin)
                {
                    return indexForLastMin;
                }
                
                if (s[i] != min && s[i] != '0')
                {
                    return i;
                }
            }

            return indexForLastMin;
        }

        private int GetFirstIndexNotZero(string s, int indexForLastZero)
        {
            for (int i = 1; i < s.Length; i++)
            {
                if (i == indexForLastZero)
                {
                    return indexForLastZero;
                }
                
                if (s[i] != '0')
                {
                    return i;
                }
            }

            return indexForLastZero;
        }
    }
}