namespace task5
{
    class Program
    {
        static int MyCharComparator(char a, char b)
        {
            if (char.IsDigit(a) && char.IsDigit(b))
            {
                return a.CompareTo(b);
            }
            if (char.IsDigit(a) && char.IsLetter(b))
            {
                return 1;
            }
            if (char.IsLetter(a) && char.IsDigit(b))
            {
                return -1;
            }
            if (char.ToLower(a) == char.ToLower(b))
            {
                return char.IsLower(a) ? -1 : 1;
            }
            return char.ToLower(a).CompareTo(char.ToLower(b));
        }

        static string SortString(string s)
        {
            char[] chars = s.ToCharArray();
            Array.Sort(chars, MyCharComparator);
            return string.Join("", chars);
        }
        static void Main(string[] args)
        {
            Console.WriteLine(SortString("eA2a1E")); //aAeE12
            Console.WriteLine(SortString("Re4r")); //erR4
            Console.WriteLine(SortString("6jnM31Q")); //jMnQ136
            Console.WriteLine(SortString("846ZIbo")); //bIoZ468
        }
    }
}