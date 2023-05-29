namespace RainWater
{
    public class RainWater
    {
        private int[] borders;

        public RainWater(int[] _borders)
        {
            if (Array.Exists(_borders, elem => elem < 0))
            {
                throw new ArgumentException("Incorrect array of borders.");
            }
            borders = _borders;
        }
        public int WaterVolume()
        {
            Stack<(int, int)> incrBord = new Stack<(int, int)>();
            int volume = 0;
            for (int i = 0; i < borders.Length; i++)
            {
                int bord = borders[i];
                int last = 0;
                while (incrBord.Count > 0 && incrBord.Peek().Item1 <= bord)
                {
                    (int, int) top = incrBord.Pop();
                    volume += (i - top.Item2 - 1) * (top.Item1 - last);
                    last = top.Item1;
                }
                if (last != bord && incrBord.Count > 0)
                {
                    (int, int) top = incrBord.Peek();
                    volume += (i - top.Item2 - 1) * (bord - last);
                }
                incrBord.Push((bord, i));
            }
            return volume;
        }
    }
}