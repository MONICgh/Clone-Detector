namespace MailBox
{
    public class Street
    {
        private int[] houses;
        public Street(int[] _houses)
        {
            houses = _houses;
            Array.Sort(houses);
        }

        public int ArrangeMailBoxesAndGetMinDistance(int mailBoxes)
        {
            int[,] dp = new int[mailBoxes + 1, houses.Length];
            int[,] minDistance = new int[houses.Length, houses.Length];
            int[] prefSumDistance = new int[houses.Length];

            int curPref = 0;
            for (int curHouse = 0; curHouse < houses.Length; curHouse++)
            {
                prefSumDistance[curHouse] = curPref + houses[curHouse];
                curPref += houses[curHouse];
            }

            for (int leftHouse = 0; leftHouse < houses.Length; leftHouse++)
            {
                int sumDistance = 0;
                for (int rightHouse = leftHouse; rightHouse < houses.Length; rightHouse++)
                {
                    int middleHouse = (leftHouse + rightHouse) / 2;
                    int leftMiddle = prefSumDistance[middleHouse] - ((leftHouse == 0) ? 0 : prefSumDistance[leftHouse - 1]);
                    int rightMiddle = prefSumDistance[rightHouse] - prefSumDistance[middleHouse];
                    minDistance[leftHouse, rightHouse] = (middleHouse - leftHouse + 1) * houses[middleHouse] - leftMiddle +
                                                          rightMiddle - (rightHouse - middleHouse) * houses[middleHouse];
                }
            }

            for (int curHouse = 0; curHouse < houses.Length; curHouse++)
            {
                dp[1, curHouse] = minDistance[0, curHouse];
            }
            for (int curMailBox = 2; curMailBox <= mailBoxes; curMailBox++)
            {
                for (int curHouse = 0; curHouse < houses.Length; curHouse++)
                {
                    dp[curMailBox, curHouse] = dp[curMailBox - 1, curHouse];
                    for (int prevHouse = 0; prevHouse < curHouse; prevHouse++)
                    {
                        dp[curMailBox, curHouse] = Math.Min(dp[curMailBox, curHouse],
                                                            dp[curMailBox - 1, prevHouse] + minDistance[prevHouse + 1, curHouse]);
                    }
                }
            }
            return dp[mailBoxes, houses.Length - 1];
        }
    }
}