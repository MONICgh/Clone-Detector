namespace task2
{
    class Program
    {
        public static void Main(string[] args)
        {
            var A = new ImmutableRectangle(10, 15);
            var B = A.ChangeLength(15);
            var C = B.ChangeWidth(20);

            Console.WriteLine(A); //Rectangle{ length:10, width:15}
            Console.WriteLine(B); //Rectangle{ length:15, width:15}  
            Console.WriteLine(C); //Rectangle{ length:15, width:20}

        }
    }
}