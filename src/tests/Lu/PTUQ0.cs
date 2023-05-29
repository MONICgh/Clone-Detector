namespace HW_09;

public class FileWriter
{
    private const int MaxNumber = 100_000_000;
    private readonly string _filename;
    private readonly Generator _generator = new();

    private class Generator
    {
        private int _number;
        private int _index;
        private readonly int _zeroIndex;

        public Generator()
        {
            var rnd = new Random();
            _number = rnd.Next(MaxNumber - 1) + 1;
            _zeroIndex = rnd.Next(MaxNumber - 1) + 1;
        }
        private void UpdateNumber()
        {
            const ulong p = 100_000_007;
            const ulong mod = 100_000_037;
            _number = (int)((ulong)_number * p % mod);
            if (_number > MaxNumber)
            {
                UpdateNumber();
            }
        }

        public int GetNumber()
        {
            _index++;
            if (_index == _zeroIndex)
            {
                return 0;
            }
            var toGet = _number;
            UpdateNumber();
            return toGet;
        }
    }

    public FileWriter(string filename)
    {
        _filename = filename;
    }

    public void WriteNumbers(int limit = MaxNumber)
    {
        for (var i = 0; i <= limit; i++)
        {
            var number = _generator.GetNumber();
            var asString = $"{number:D8}";
            File.AppendAllText(_filename, asString);
        }
    }
}
