namespace Task4;

public class MailPlaces
{
    private List<int> _houses;
    
    public int Apply(List<int> houses, int k)
    {
        houses.Sort();
        _houses = houses;
        return CountForSubList(0, houses.Count, k);
    }

    private int CountForSubList(int l, int r, int k)
    {
        if (r - l <= k)
        {
            return 0;
        }

        if (k == 0)
        {
            return Int32.MaxValue;
        }

        int best = Int32.MaxValue;
        if (k == 1)
        {
            for (int i = l; i < r; i++)
            {
                int t = 0;
                for (int j = l; j < r; j++)
                {
                    t += Math.Abs(_houses[j] - _houses[i]);
                }

                best = Math.Min(best, t);
            }

            return best;
        }
        
        for (int i = 1; i <= r - l - 1; i++)
        {
            var t = CountForSubList(l, l + i, 1) + CountForSubList(l + i, r, k - 1);
            best = Math.Min(best, t);
        }

        return best;
    }
}