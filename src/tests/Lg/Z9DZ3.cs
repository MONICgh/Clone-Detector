using System;
using System.Threading;
using static System.Collections.Specialized.BitVector32;

namespace Lab16
{
    public class MatrixMultiplication
    {
        int[,] A, B, C;
        bool[,] calculated;
        int m, n, k;
        class Element
        {
            public int x, y;
        }

        private void ComputeElement(object _elem)
        {
            Element elem = (Element)_elem;
            C[elem.x, elem.y] = 0;
            for (int i = 0; i < m; ++i)
            {
                C[elem.x, elem.y] += A[elem.x, i] * B[i, elem.y];
            }
        }
        private void ComputeElements(object _range)
        {
            Element range = (Element)_range;
            for (int i = range.x; i < range.y; ++i)
            {
                for (int j = range.x; j < range.y; ++j)
                {
                    Element elem = new Element();
                    elem.x = i;
                    elem.y = j;
                    for (int k = 0; k < m; ++k)
                    {
                        ComputeElement(elem);
                    }
                }
            }
        }
        private void ParallelThreadSplitMultiply(int split)
        {
            int subLength = m / split;
            Thread[] th = new Thread[split];
            Element elem;
            for (int i = 0; i < split; ++i)
            {
                elem = new Element();
                th[i] = new Thread(new ParameterizedThreadStart(ComputeElements));
                elem.x = i * subLength;
                elem.y = (i + 1) * subLength;
                th[i].Start(elem); 
            }
            for (var i = 0; i < split; ++i)
            {
                th[i].Join();
            }
        }

        public MatrixMultiplication(int[,] a, int[,] b, int thread_num)
        {
            A = a; B = b;
            m = a.GetLength(0);
            n = a.GetLength(1);
            int n1 = b.GetLength(0);
            k = b.GetLength(1);
            if (n != n1)
                throw new ArgumentException("Invalid input");

            calculated = new bool[m, k];
            ParallelThreadSplitMultiply(thread_num);                
        }

    }
}
