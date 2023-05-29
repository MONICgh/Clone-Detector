using System.Collections;

namespace Application
{
    class Lake : IEnumerable<int>
    {
        List<int> elements = new List<int>();

        public Lake(List<int> elements)
        {
            this.elements = elements;
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new LakeIterator(elements);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class LakeIterator : IEnumerator<int>
        {
            private readonly List<int> elements;
            private int currentIndex;
            private int length;

            public LakeIterator(IEnumerable<int> elements)
            {
                this.Reset();
                this.elements = new List<int>(elements);
                length = elements.Count();
            }

            public bool MoveNext() {
                if (currentIndex % 2 == 0)
                {
                    if (currentIndex + 2 < length)
                    {
                        currentIndex += 2;
                        return true;
                    }
                    else
                    {
                        if (currentIndex + 1 < length)
                        {
                            currentIndex += 1;
                            return true;
                        }
                        else
                        {
                            currentIndex -= 1;
                            return currentIndex > 0;
                        }
                    }
                }
                else
                {
                    currentIndex -= 2;
                    return currentIndex > 0;
                }
            }

            public void Reset() => currentIndex = -2;

            public int Current => elements[currentIndex];

            object IEnumerator.Current => Current;

            public void Dispose() { }
        }
    }

    class Task1
    {
        static void ShowPath(List<int> stones)
        {
            Lake lake = new Lake(stones);
            foreach (int stone in lake)
            {
                Console.Write("{0} ", stone);
            }
            Console.WriteLine();
        }

        static void Main()
        {
            var stones = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
            ShowPath(stones);
            var stones2 = new List<int>() { 13, 23, 1, -8, 4, 9 };
            ShowPath(stones2);
            var stones3 = new List<int>() { 1 };
            ShowPath(stones3);
            var stones4 = new List<int>() { 1, 2 };
            ShowPath(stones4);

        }
    }
}
