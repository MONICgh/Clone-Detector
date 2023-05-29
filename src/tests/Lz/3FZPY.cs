namespace PseudoStack
{
    public class PseudoStack<T>
    {
        private int maxSize;
        private List<Stack<T>> listStack;
        public PseudoStack(int _maxSize)
        {
            listStack = new List<Stack<T>>();
            maxSize = _maxSize;
        }

        public void Push(T value)
        {
            if (!listStack.Any() || listStack.Last().Count == maxSize)
            {
                listStack.Add(new Stack<T>());
            }
            listStack.Last().Push(value);
        }

        public T Pop()
        {
            if (!listStack.Any())
            {
                throw new Exception("Stack is empty");
            }
            T element = listStack.Last().Pop();
            if (listStack.Last().Count == 0)
            {
                listStack.RemoveAt(listStack.Count - 1);
            }
            return element;
        }
    }
}