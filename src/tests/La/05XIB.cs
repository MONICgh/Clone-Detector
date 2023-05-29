
namespace task3
{
    class Envelope
    {
        public int Height { get; private set; }
        public int Width { get; private set; }
        public int MinSide { get; private set; }
        public int MaxSide { get; private set; }

        public Envelope(int width, int height)
        {
            Width = width;
            Height = height;
            MinSide = Math.Min(width, height);
            MaxSide = Math.Max(width, height);
        }
        
        public static bool operator < (Envelope a, Envelope b)
        {
            return a.MinSide < b.MinSide && a.MaxSide < b.MaxSide;
        }
        public static bool operator > (Envelope a, Envelope b)
        {
            return a.MinSide > b.MinSide && a.MaxSide > b.MaxSide;
        }

        public override string ToString()
        {
           return "[" + Width + ", " + Height + "]";
        }
    }
}
