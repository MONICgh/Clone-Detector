namespace task3
{
    class Program
    {
        public static void Main(string[] args)
        {
            var stack = new MinStack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Pop();
            Console.WriteLine(stack); // {2, 1}
            Console.WriteLine($"Stack top: {stack.Peek()}"); // 2
            Console.WriteLine($"Stack minimum: {stack.MinValue()}"); // 1
            Console.WriteLine($"Stack count: {stack.Count}"); // 2
            Console.WriteLine(stack.Contains(4)); // False
            Console.WriteLine(stack.Contains(2)); // True

            stack.Clear();
            Console.WriteLine($"Stack count: {stack.Count}"); // 0
        }
    }
}
