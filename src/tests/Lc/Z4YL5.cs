using System.Collections.Concurrent;

namespace Task4;

public class SudokuChecker
{
    private volatile bool _result = true; 
    
    private struct OneCheck
    {
        public int Number;
        public char Type;
        
        public OneCheck(int number, char type)
        {
            Number = number;
            Type = type;
        }
    }

    private List<List<string>> _sudoku;
    private ConcurrentQueue<OneCheck> _checks = new ConcurrentQueue<OneCheck>();

    public bool Check(List<List<string>> sudoku)
    {
        _sudoku = sudoku;
        _checks.Clear();
        _result = true;
        for (int i = 0; i < 9; i++)
        {
            _checks.Enqueue(new OneCheck(i, 'R'));
            _checks.Enqueue(new OneCheck(i, 'C'));
            _checks.Enqueue(new OneCheck(i, 'S'));
        }

        List<Thread> threads = new List<Thread>();
        for (int i = 0; i < 4; i++)
        {
            var thread = new Thread(CheckThread);
            threads.Add(thread);
            thread.Start();
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }

        return _result;
    }

    private bool CheckOne(OneCheck check)
    {
        HashSet<string> elems = new HashSet<string>();
        if (check.Type == 'L')
        {
            for (int i = 0; i < 9; i++)
            {
                var el = _sudoku[check.Number][i];
                if (el == ".")
                    continue;
                if (elems.Contains(el))
                    return false;
                elems.Add(el);
            }
        }

        if (check.Type == 'C')
        {
            for (int i = 0; i < 9; i++)
            {
                var el = _sudoku[i][check.Number];
                if (el == ".")
                    continue;
                if (elems.Contains(el))
                    return false;
                elems.Add(el);
            }
        }

        if (check.Type == 'S')
        {
            int baseLine = (check.Number / 3) * 3;
            int baseCol = (check.Number % 3) * 3;
            for (int i = 0; i < 9; i++)
            {
                var el = _sudoku[baseLine + i / 3][baseCol + i % 3];
                if (el == ".")
                    continue;
                if (elems.Contains(el))
                    return false;
                elems.Add(el);
            }
        }

        return true;
    }
    
    private void CheckThread()
    {
        OneCheck check;
        while (_checks.TryDequeue(out check) && _result)
        {
            if (!CheckOne(check))
                _result = false;
        }
    }
}