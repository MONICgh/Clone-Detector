namespace Task2;

public abstract class Animal
{
    public int X, Y;
    protected Random _random = new Random();
    protected Board _board;
    
    protected void MakeMove()
    {
        int newX = X, newY = Y;
        while (!((newX != X || newY != Y) && newX >= 0 && newX < _board.N && newY >= 0 && newY < _board.N))
        {
            newX = X + _random.Next(-1, 2);
            newY = Y + _random.Next(-1, 2);
        }

        X = newX;
        Y = newY;
    }
}