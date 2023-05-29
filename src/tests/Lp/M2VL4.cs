using System.Text;

namespace GeneratePermutations
{
    public static class Permutation
    {
        public static string GenerateAllPermutations(string s)
        {
            char[] letters = s.ToCharArray();
            Array.Sort(letters);
            StringBuilder sb = new();
            foreach (char c in letters) 
            {
                sb.Append(c);
            }

            while (true)
            {
                char mx = letters.Last();
                int position = -1;

                for (int i = letters.Length - 1; i >= 0; i--)
                {
                    if (letters[i] < mx)
                    {
                        position = i;
                        break;
                    }
                    mx = letters[i];
                }

                if (position == -1)
                {
                    break;
                }

                for (int i = letters.Length - 1; i >= 0; i--)
                {
                    if (letters[i] > letters[position])
                    {
                        (letters[i], letters[position]) = (letters[position], letters[i]);
                        Array.Reverse(letters, position + 1, letters.Length - 1 - position);
                        break;
                    }
                }

                sb.Append(' ');
                foreach (char c in letters)
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}