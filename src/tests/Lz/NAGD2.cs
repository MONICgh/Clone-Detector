namespace Application
{
    class PseudoStack<T>
    {
        private int stackSize;

        private List<Stack<T>> stacks = new List<Stack<T>>();

        public PseudoStack(int stackSize)
        {
            this.stackSize = stackSize;
        }

        private bool lastStackFull()
        {
            return stacks.Count() == 0 || stacks.Last().Count() == stackSize;
        }

        private bool lastStackEmpty()
        {
            if (stacks.Count() == 0)
                return false;
            return stacks.Last().Count() == 0;
        }

        public void Push(T value)
        {
            if (lastStackFull())
            {
                stacks.Add(new Stack<T>());
            }
            stacks.Last().Push(value);
        }

        public T Pop()
        {
            if (!stacks.Any()) {
                throw new Exception("stack is empty");
            }
            T value = stacks.Last().Pop();
            if (lastStackEmpty())
            {
                stacks.RemoveAt(stacks.Count - 1);
            }
            return value;
        }

        public bool Empty()
        {
            return stacks.Count() == 0;
        }
    }

    class Task1
    {
        static void Main()
        {
            var stack = new PseudoStack<int>(2);
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(6);
            Console.WriteLine("{0}", stack.Pop());
            stack.Push(5);
            while (!stack.Empty())
            {
                Console.WriteLine("{0}", stack.Pop());
            }
        }
    }
}
