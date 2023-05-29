namespace ChaiseLongue
{
    public static class ChaiseLongue
    {
        public static int SunLoungers(string beach)
        {
            int rightPlace = 0;
            int lastOccupied = -2;
            for (int i = 0; i < beach.Length; i++)
            {
                if (beach[i] == '1')
                {
                    lastOccupied = i;
                }
                else
                {
                    if (lastOccupied + 1 < i && (i == beach.Length - 1 || beach[i + 1] == '0'))
                    {
                        lastOccupied = i;
                        rightPlace++;
                    }
                }
            }
            return rightPlace;
        }
    }
}