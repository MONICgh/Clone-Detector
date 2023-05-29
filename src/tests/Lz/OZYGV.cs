namespace HW_05.SunLoungers;

public class SunLoungersSolver
{
    public static int Solve(string data)
    {
        var positions = data.ToList();
        var ans = 0;
        for (int i = 0; i < positions.Count(); i++)
        {
            var current = positions[i] == '1';
            if (current)
                continue;
            var prev = i > 0 && positions[i - 1] == '1';

            var next = i + 1 < positions.Count && positions[i + 1] == '1';

            if (prev || next)
                continue;
            positions[i] = '1';
            ans++;
        }
        return ans;
    }
}
