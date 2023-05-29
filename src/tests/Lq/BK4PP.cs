using System.Text;

namespace CarRace
{
    public class RacingCar
    {
        private readonly int finish_position;
        public RacingCar(int _finish_position)
        {
            finish_position = _finish_position;
        }

        private bool CheckLowestBitsAreOnes(int x)
        {
            return (x & (x + 1)) == 0;
        }

        private void Go(int len, StringBuilder sb)
        {
            while (len > 0)
            {
                sb.Append('A');
                len /= 2;
            }
        }

        public string BuildRoute()
        {
            if (finish_position == 0)
            {
                return "";
            }

            int zero_tail = 0;
            int copy_position = Math.Abs(finish_position);
            while (copy_position % 2 == 0)
            {
                zero_tail = 2 * zero_tail + 1;
                copy_position /= 2;
            }

            if (!CheckLowestBitsAreOnes(Math.Abs(finish_position) + zero_tail))
            {
                return "Can't reach this position";
            }

            StringBuilder sb = new();
            if (finish_position > 0)
            {
                Go(finish_position + zero_tail, sb);
                if (zero_tail != 0)
                {
                    sb.Append('R');
                    Go(zero_tail, sb);
                }
            }
            else
            {
                if (zero_tail != 0)
                {
                    Go(zero_tail, sb);
                }
                sb.Append('R');
                Go(-finish_position + zero_tail, sb);
            }
            return sb.ToString();
        }
    }
}