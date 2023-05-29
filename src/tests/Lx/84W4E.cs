using System.Collections.Generic;

namespace task3
{
    class MinStack<T> where T : IComparable
    {
        private Stack<T> mainStack;
        private Stack<T> minsStack;
        public int Count { get; private set; }

        public MinStack() 
        {
            mainStack = new Stack<T>(); 
            minsStack = new Stack<T>();
            Count = 0;
        }

        public void Clear()
        {
            mainStack.Clear();
            minsStack.Clear();
            Count = 0;
        }
        public bool Contains(T value)
        {
            return mainStack.Contains(value);
        }
     
        public T MinValue()
        {
            return minsStack.Peek();
        }
        public T Peek()
        {
            return mainStack.Peek();
        }
        public T Pop()
        {
            minsStack.Pop();
            Count--;
            return mainStack.Pop();
        }
        public void Push(T value)
        {
            mainStack.Push(value);
            if (minsStack.Count == 0 || value.CompareTo(minsStack.Peek()) < 0)
            {
                minsStack.Push(value);
            }
            else
            {
                minsStack.Push(minsStack.Peek());
            }
            Count++;
        }

        public override string ToString()
        {
            string outputString = "";

            foreach (var item in mainStack)
            {
                outputString += item.ToString() + ", ";
            }

            outputString = outputString.Remove(outputString.Length - 2, 2);
            return "{" + outputString +"}";
        }
    }
}
