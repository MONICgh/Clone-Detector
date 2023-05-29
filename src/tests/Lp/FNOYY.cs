namespace Cache;

public static class Utils
{
    private static int currentIndex = 0;

    public static int getNextIndex()
    {
        currentIndex++;
        return currentIndex;
    }
}