namespace HW_11.Permutations;

public static class Permutations
{

    public static string GenerateLine(string data)
    {
        var str = string.Join("", data.OrderBy(it => it));
        var list = new List<String>();
        while (true)
        {
            list.Add(str);
            str = GetNextPermutation(str);
            if (str == null)
                break;
        }
        list.Sort();
        return string.Join(" ", list);
    }
    public static string? GetNextPermutation(String prev)
    {
        var data = prev.ToArray();
        var startIndex = data.Length - 2;

        while (startIndex >= 0)
        {
            if (data[startIndex] < data[startIndex + 1])
            {
                break;
            }
            --startIndex;
        }
        if (startIndex >= 0)
        {
            var endIndex = data.Length - 1;
            while (endIndex > startIndex)
            {
                if (data[endIndex] > data[startIndex])
                {
                    break;
                }
                --endIndex;
            }
            (data[startIndex], data[endIndex]) = (data[endIndex], data[startIndex]);
        }
        else
        {
            return null;
        }

        // Reverse the array
        Reverse(data, startIndex + 1);
        return string.Join("", data);
    }

    private static void Reverse(IList<char> nums, int startIndex)
    {
        for (int start = startIndex, end = nums.Count - 1; start < end; ++start, --end)
        {
            (nums[start], nums[end]) = (nums[end], nums[start]);
        }
    }

}
