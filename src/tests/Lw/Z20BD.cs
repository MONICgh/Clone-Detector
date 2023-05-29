using System.Runtime.Intrinsics.X86;

namespace Task2;

public class Wolf: Animal
{
    public Wolf(int x, int y, Board board)
    {
        X = x;
        Y = y;
        _board = board;
        new Thread(Live).Start();
    }

    private void Live()
    {
        while (true)
        {
            Thread.Sleep(_random.Next(100, 500));
            lock (_board.Locker)
            {
                MakeMove();
                Console.WriteLine("Волк пошел на клетку (" + X + ", " + Y + ")");

                for (int i = 0; i <= _board.NumberSheeps; i++)
                {
                    if (!_board.Sheeps.ContainsKey(i))
                        continue;
                    if (_board.Sheeps[i].X == X && _board.Sheeps[i].Y == Y)
                    {
                        _board.WolfEats(i);
                    }
                }
            }
        }
    }
}