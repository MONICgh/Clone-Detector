namespace StackMin
{
    public class StackMin
    {
        private Stack<Tuple<int, int>> stack;

        public StackMin()
        {
            stack = new Stack<Tuple<int, int>>();
        }
        public void Push(int value)
        {
            if (stack.Count == 0)
            {
                stack.Push(new Tuple<int, int>(value, value));
            }
            else
            {
                stack.Push(new Tuple<int, int>(value, Math.Min(value, stack.Peek().Item2)));
            }
        }

        public void Pop()
        {
            stack.Pop();
        }

        public int Top()
        {
            return stack.Peek().Item1;
        }

        public int MinValue()
        {
            return stack.Peek().Item2;
        }
    }
}