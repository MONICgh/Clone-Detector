using System.Linq;

namespace SunLongers
{
    class Beach
    {
        public string Places = "";
        public Beach(string places)
        {
            if (places.All(place => place == '1' || place == '0'))
            {
                Places = places;
            }
        }

        public int NumberOfFreeSunLongers()
        {
            if (Places == "")
            {
                return 0;
            }
            
            if (Places.All(place => place == '0'))
            {
                return (Places.Length + 1) / 2;
            }
            
            var answer = 0;
            (var firstBusy, var lastBusy) = GetFirstLastBusy();

            if (firstBusy != -1)
            {
                answer += firstBusy / 2;
            }
            
            if (lastBusy != -1)
            {
                answer += (Places.Length - lastBusy - 1) / 2;
            }

            var nearestBusy = firstBusy;

            for (var i = firstBusy + 1; i <= lastBusy; i++)
            {
                if (Places[i] == '1')
                {
                    if (i - nearestBusy - 2 >= 0)
                    {
                        answer += (i - nearestBusy - 2) / 2;
                        nearestBusy = i;
                    }
                }
            }

            return answer;
        }

        private (int, int) GetFirstLastBusy()
        {
            var firstBusy = -1;
            for (var i = 0; i < Places.Length && firstBusy == -1; i++)
            {
                if (Places[i] == '1')
                {
                    firstBusy = i;
                }
            }

            var lastBusy = -1;
            
            for (var i = Places.Length - 1; i >= 0 && lastBusy == -1; i--)
            {
                if (Places[i] == '1')
                {
                    lastBusy = i;
                }
            }

            return (firstBusy, lastBusy);
        }
    }
}