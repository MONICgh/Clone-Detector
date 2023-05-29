using System.Text;

namespace HW_12;

public static class TaskCar
{

    public static string Solve(int n)
    {
        switch (n)
        {
            case -1:
                return "RA";
            case < 1:
                return "Impossible";
        }

        int limit = 3 * n;
        var data = new List<int>();
        var parent = new List<string>();
        for (int i = 0; i <= limit + 5; i++)
        {
            data.Add(5 * limit);
            parent.Add($"-----");
        }
        data[0] = 0;
        for (int k = 0;; k++)
        {
            int shift = (1 << k) - 1;
            if (shift > limit)
                break;
            data[shift] = k;
            parent[shift] = $"A{k}";
        }

        for (var i = 0; i < limit; i++)
        {
            for (var t = 1;; t++)
            {
                var shift = (1 << t) - 1;
                if (i + shift > limit)
                    break;
                if (data[i] + t + 2 >= data[i + shift])
                    continue;
                data[i + shift] = data[i] + t + 2;
                parent[i + shift] = $"RA{t}";
            }
        }
        var index = n;
        for (var i = n; i <= limit; i++)
        {
            if (data[i] + (i - n) * 2 < data[index] + (index - n) * 2)
            {
                index = i;
            }
        }
        var save = new StringBuilder();
        while (n < index)
        {
            save.Append("RA");
            n++;
        }
        var answer = new StringBuilder();
        while (index != 0)
        {
            var res = parent[index];
            if (res.StartsWith("RA"))
            {
                var t = int.Parse(res[2..]);
                var shift = (1 << t) - 1;
                answer.Append("RA");
                for (int i = 0; i < t; i++)
                {
                    answer.Append('A');
                }
                index -= shift;
            }
            else
            {
                var t = int.Parse(res[1..]);
                var shift = (1 << t) - 1;
                for (var i = 0; i < t; i++)
                {
                    answer.Append('A');
                }
                index -= shift;
            }
        }
        answer.Append(save);
        return answer.ToString();
    }
}
