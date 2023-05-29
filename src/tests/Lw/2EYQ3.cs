
namespace task1
{
    class HoneyPot
    {
        public readonly int Size;
        public int Portions = 0;

        public HoneyPot(int size)
        {
            Size = size;
        }

        public bool IsFull()
        {
            return Portions == Size;
        }

        public void AddPortion()
        {
            Portions++;
        }
        public void Empty()
        {
            Portions = 0;
        }
    }
}
