namespace MergeSort
{
    public class MergeSort
    {
        private readonly int threads;
        public MergeSort(int _threads)
        {
            threads = _threads;
        }

        private void merge<T>(T[] array, int lefBound, int mid, int rigBound) where T : IComparable<T>
        {
            T[] sortedCopy = new T[rigBound - lefBound + 1];

            int lefPtr = lefBound, rigPtr = mid + 1;
            int total = 0;
            while (total != rigBound - lefBound + 1)
            {
                if (lefPtr != mid + 1 && (rigPtr == rigBound + 1 || array[lefPtr].CompareTo(array[rigPtr]) <= 0))
                {
                    sortedCopy[total++] = array[lefPtr++];
                }
                else
                {
                    sortedCopy[total++] = array[rigPtr++];
                }
            }

            for (int i = lefBound; i <= rigBound; i++)
            {
                array[i] = sortedCopy[i - lefBound];
            }
        }

        private void mergeSort<T>(T[] array, int lefBound, int rigBound) where T : IComparable<T>
        {
            if (lefBound == rigBound)
            {
                return;
            }
            int mid = (lefBound + rigBound) / 2;
            mergeSort(array, lefBound, mid);
            mergeSort(array, mid + 1, rigBound);
            merge(array, lefBound, mid, rigBound);
        }

        public void SortWaitAll<T>(T[] array) where T : IComparable<T>
        {
            int len = array.Length;

            Thread[] thr = new Thread[threads];
            int ptr = 0;
            for (int i = 0; i < threads; i++)
            {
                int segmentLen = (len - ptr) / (threads - i);
                if (segmentLen == 0)
                {
                    thr[i] = new Thread(() => { });
                }
                else
                {
                    int curSeg = ptr;
                    thr[i] = new Thread(() =>
                    {
                        Thread.Sleep(2000);
                        mergeSort(array, curSeg, curSeg + segmentLen - 1);
                    });
                }
                ptr += segmentLen;
            }

            for (int i = 0; i < threads; i++)
            {
                thr[i].Start();
            }
            for (int i = 0; i < threads; i++)
            {
                thr[i].Join();
            }

            ptr = 0;
            for (int i = 0; i < threads; i++)
            {
                int segmentLen = (len - ptr) / (threads - i);
                if (segmentLen == 0)
                {
                    continue;
                }
                if (ptr != 0)
                {
                    merge(array, 0, ptr - 1, ptr + segmentLen - 1);
                }
                ptr += segmentLen;
            }
        }

        public void SortWithoutWait<T>(T[] array) where T : IComparable<T>
        {
            int len = array.Length;

            Queue<int> done = new();

            Thread[] thr = new Thread[threads];
            (int, int)[] bounds = new (int, int)[threads];
            int ptr = 0;
            for (int i = 0; i < threads; i++)
            {
                int segmentLen = (len - ptr) / (threads - i);
                bounds[i] = (ptr, ptr + segmentLen - 1);
                if (segmentLen == 0)
                {
                    int curNum = i;
                    thr[i] = new Thread(() => 
                    {
                        lock (done)
                        {
                            done.Enqueue(curNum);
                            Monitor.Pulse(done);
                        }
                    });
                }
                else
                {
                    int curSeg = ptr;
                    int curNum = i;
                    thr[i] = new Thread(() =>
                    {
                        Thread.Sleep((curNum + 1) * 1000);
                        mergeSort(array, curSeg, curSeg + segmentLen - 1);
                        lock (done)
                        {
                            done.Enqueue(curNum);
                            Monitor.Pulse(done);
                        }
                    });
                }
                ptr += segmentLen;
            }

            for (int i = 0; i < threads; i++)
            {
                thr[i].Start();
            }

            int finished = 0;
            T[] sortedArray = new T[len];
            int alreadySorted = 0;

            while (finished != threads)
            {
                int finishedThread = -1;
                lock (done)
                {
                    if (done.Count == 0)
                    {
                        Monitor.Wait(done);
                    }
                    if (done.Count > 0)
                    {
                        finishedThread = done.Dequeue();
                    }
                }
                if (finishedThread == -1)
                {
                    continue;
                }

                finished++;
                if (bounds[finishedThread].Item1 > bounds[finishedThread].Item2)
                {
                    continue;
                }
                for (int i = bounds[finishedThread].Item1; i <= bounds[finishedThread].Item2; i++)
                {
                    sortedArray[alreadySorted + i - bounds[finishedThread].Item1] = array[i];
                }
                merge(sortedArray, 0, alreadySorted - 1, alreadySorted + bounds[finishedThread].Item2 -
                    bounds[finishedThread].Item1);
                alreadySorted += bounds[finishedThread].Item2 - bounds[finishedThread].Item1 + 1;
            }

            for (int i = 0; i < len; i++)
            {
                array[i] = sortedArray[i];
            }
        }
    }
}