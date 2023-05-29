namespace HW_07;

public static class Tasks
{
    public static (ulong Mini, ulong Maxi) maxMin(ulong number)
    {
        var s = number.ToString();


        ulong maxi(char[] s)
        {
            ulong answer = number;
            int index = s.Length - 1;

            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] > s[index])
                {
                    index = i;
                }
                (s[index], s[i]) = (s[i], s[index]);
                answer = Math.Max(answer, ulong.Parse(s));
                (s[index], s[i]) = (s[i], s[index]);
            }
            return answer;
        }

        ulong mini(char[] s)
        {
            ulong answer = number;
            int indexWithZero = s.Length - 1;
            int indexWithNoZero = -1;

            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] < s[indexWithZero])
                {
                    indexWithZero = i;
                }
                if (s[i] != '0' && (indexWithNoZero == -1 || s[i] < s[indexWithNoZero]))
                {
                    indexWithNoZero = i;
                }

                if (i != 0)
                {
                    (s[indexWithZero], s[i]) = (s[i], s[indexWithZero]);
                    answer = Math.Min(answer, ulong.Parse(s));
                    (s[indexWithZero], s[i]) = (s[i], s[indexWithZero]);
                }
                if (indexWithNoZero != -1)
                {
                    (s[indexWithNoZero], s[i]) = (s[i], s[indexWithNoZero]);
                    answer = Math.Min(answer, ulong.Parse(s));
                    (s[indexWithNoZero], s[i]) = (s[i], s[indexWithNoZero]);
                }
            }
            return answer;
        }

        return (Mini: mini(s.ToCharArray()), Maxi: maxi(s.ToCharArray()));
    }

    public static List<List<int>> ThreeSum(List<int> data)
    {
        IEnumerable<List<int>> twoSum(int start, int expsum)
        {
            var ans = new List<List<int>>();
            int k = data.Count - 1;
            for (int i = start; i < k; i++)
            {
                while (k > i && data[i] + data[k] > expsum)
                    k--;
                if (k > i)
                {
                    if (data[i] + data[k] == expsum)
                    {
                        ans.Add(new List<int> { data[i], data[k] });
                    }
                }
            }
            return ans;
        }

        var ans = new List<List<int>>();
        data.Sort();
        for (var i = 0; i < data.Count - 2; i++)
        {
            ans.AddRange(twoSum(i + 1, -data[i]).Select(ints => new List<int> { data[i], ints[0], ints[1] }));
        }

        return ans.OrderBy(t => t.First()).ToList();
    }
}
