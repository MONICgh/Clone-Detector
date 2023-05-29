namespace Matryoshka
{
    public class Envelope
    {
        public int Width { set; get; }
        public int Height { set; get; }

        public Envelope(int w, int h)
        {
            Width = w;
            Height = h;
        }

        public static int MaxMatryoshka(Envelope[] arr)
        {
            Array.Sort(arr, (e1, e2) => Math.Min(e1.Width, e1.Height).CompareTo(Math.Min(e2.Width, e2.Height)));
            int[] increaseSequence = new int[arr.Length];
            int maxSequence = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                increaseSequence[i] = 1;
                for (int j = 0; j < i; j++)
                {
                    if ((arr[j].Width < arr[i].Width && arr[j].Height < arr[i].Height) ||
                        (arr[j].Height < arr[i].Width && arr[j].Width < arr[i].Height))
                    {
                        increaseSequence[i] = Math.Max(increaseSequence[i], increaseSequence[j] + 1);
                    }
                }
                maxSequence = Math.Max(maxSequence, increaseSequence[i]);
            }
            return maxSequence;
        }
    }
}