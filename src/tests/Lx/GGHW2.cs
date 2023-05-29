namespace task2
{
    class Program
    {
        public static void Main(string[] args)
        {
            var generator = new PasswordGenerator();
            Console.WriteLine(generator.GetPassword()); // 8Y2NBIAY(#<_l 

        }
    }
}
