namespace Deckchairs
{
    public class DeckchairsSolver
    {
        public int Solve(string beach)
        {
            int ans = 0, cnt = 0;
            int n = beach.Length;
            for (var i = 0; i < n; ++i)
            {
                if (beach[i] == '0')
                {
                    ++cnt;
                }
                
                if (beach[i] == '1' || i == n - 1)
                {
                    var begin = cnt == i || cnt == n ? 1 : 0;
                    var end = i == n - 1 && beach[i] == '0' ? 1 : 0;
                    
                    ans += (cnt + begin + end - 1) / 2;
                    cnt = 0;
                }
            }

            return ans;
        }
    }
}