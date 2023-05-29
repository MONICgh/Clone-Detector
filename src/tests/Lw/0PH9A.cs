namespace Task2;

public class Sheep: Animal
{
    private int _number;

    public Sheep(int number, int x, int y, Board board)
    {
        _number = number;
        X = x;
        Y = y;
        _board = board;
        new Thread(Live).Start();
    }

    private bool _die = false;

    public void Die()
    {
        _die = true;
    }

    private void Live()
    {
        Console.WriteLine("Родилась новая овечка #" + _number + " на клетке (" + X + ", " + Y + ")");
        while (!_die)
        {
            lock (_board.Locker)
            {
                MakeMove();
                Console.WriteLine("Овца #" + _number + " пошла на клетку (" + X + ", " + Y + ")");
                if (_board.Wolf.X == X && _board.Wolf.Y == Y)
                {
                    _board.WolfEats(_number);
                    continue;
                }

                foreach (Sheep sheep in _board.Sheeps.Values)
                {
                    if (sheep._number == _number)
                        continue;
                    if (sheep.X == X && sheep.Y == Y)
                    {
                        _board.SheepBirth(X, Y);
                        break;
                    }
                }
            }
            Thread.Sleep(_random.Next(500, 2000));
        }
        Console.WriteLine("Овечка #" + _number + " съедена...");
    }
}