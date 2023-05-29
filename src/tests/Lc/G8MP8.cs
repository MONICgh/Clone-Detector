namespace Sudoku;

public class SudokuChecker
{
    private readonly List<List<string>> _sudoku;
    List<bool> results = new List<bool>(27);
    List<Thread> threads = new List<Thread>(27);

    public SudokuChecker(List<List<string>> sudoku)
    {
        _sudoku = sudoku;
    }

    private static bool CheckPoints(IEnumerable<string> points)
    {
        try
        {
            var allNumbers = points.Where(it => it != ".").Select(int.Parse).ToList();
            var allAreOneToNine = allNumbers.All(it => it is >= 1 and <= 9);
            var allDifference = new HashSet<int>(allNumbers).Count == allNumbers.Count;
            return allDifference && allAreOneToNine;
        }
        catch
        {
            return false;
        }
    }

    private List<string> getRow(int num)
    {
        return _sudoku[num];
    }
    
    private List<string> getColumn(int num)
    {
        return _sudoku.Select(it => it[num]).ToList();
    }
    
    private List<string> getBox(int num)
    {
        var res= _sudoku
            .Skip(3 * (num / 3))
            .Take(3)
            .SelectMany(it => it.Skip(3 * (num % 3)).Take(3))
            .ToList();
        return res;
    }

    private void SaveResult(bool result)
    {
        lock (results)
        {
            results.Add(result);
        }
    }

    public bool CheckTable()
    {
        for (int i = 0; i < _sudoku.Count; i++)
        {
            var i1 = i;
            threads.Add(new Thread(_ => SaveResult(CheckPoints(getRow(i1)))));
            var i2 = i;
            threads.Add(new Thread(_ => SaveResult(CheckPoints(getColumn(i2)))));
            var i3 = i;
            threads.Add(new Thread(_ => SaveResult(CheckPoints(getBox(i3)))));
        }
        threads.ForEach(it => it.Start());
        threads.ForEach(it => it.Join());

        lock (results)
        {
            return results.TrueForAll(it => it);
        }
    }
}