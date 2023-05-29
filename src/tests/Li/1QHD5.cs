namespace task3
{
    class Program
    {
        static bool DifferByOneChar(string s1, string s2)
        {
            int distance = StringDifference.LevensteinDistance(s1, s2);
            return distance == 1;
        }
        static void Main(string[] args)
        {
            string s1 = "Hey";
            string s2 = "ey";
            Console.WriteLine(DifferByOneChar(s1, s2)); //True 

            s2 = "Hey";
            Console.WriteLine(DifferByOneChar(s1, s2)); //False

            s2 = "Heyyyyyy";
            Console.WriteLine(DifferByOneChar(s1, s2)); //False

        }
    }
}