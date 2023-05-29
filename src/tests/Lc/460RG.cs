namespace SudokuChecker;

public class SudokuChecker
{
    private bool _res = true;
    
    public bool Check(List<List<string>> table)
    {
        _res = true;

        var threads = new List<Thread>();

        for (int i = 0; i < 9; i++)
        {
            var index = i;
            threads.Add(new Thread(() => CheckSequence(GetRowByIndex(table, index))));
            threads.Add(new Thread(() => CheckSequence(GetColumnByIndex(table, index))));
            threads.Add(new Thread(() => CheckSequence(GetBlockByIndex(table, index))));
        }

        foreach (var thread in threads)
        {
            thread.Start();
        }
        foreach (var thread in threads)
        {
            thread.Join();
        }

        return _res;
    }

    private static List<string> GetRowByIndex(List<List<string>> table, int i)
    {
        return table[i];
    }

    private static List<string> GetColumnByIndex(List<List<string>> table, int i)
    {
        return table.Select(row => row[i]).ToList();
    }

    private static List<string> GetBlockByIndex(List<List<string>> table, int i)
    {
        var block = new List<string>();
        var r = (i / 3) * 3;
        var c = (i % 3) * 3;

        for (var k = r; k < r + 3; k++)
        {
            for (var m = c; m < c + 3; m++)
            {
                block.Add(table[k][m]);
            }
        }

        return block;
    }

    private void CheckSequence(IEnumerable<string> seq)
    {
        var numericList = seq
            .Where(it => it != ".")
            .Select(it => Convert.ToInt32(it))
            .ToList();
        numericList.Sort();
        var numericSet = new HashSet<int>(numericList);
        _res &= numericList.All(it => it >= 1 && it <= 9) && numericList.Count == numericSet.Count;
    }
}