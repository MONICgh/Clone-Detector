using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab6
{
    class LakeEnumerator : IEnumerator<int>
    {
        List<int> list;
        int position = -2;
        public LakeEnumerator(List<int> list) => this.list = list;
        public int Current
        {
            get
            {
                if (position < 0 || position >= list.Count)
                    throw new ArgumentException();
                return list[position];
            }
        }
        object IEnumerator.Current
        {
            get { return Current; }
        }
        public bool MoveNext()
        {
            if (position == 1 || position >= list.Count)
            {
                return false;
            }
            position += (position % 2 == 0) ? 2 : -2;
            if (position == list.Count) position -= 1;
            return true;
        }
        public void Reset() => position = -2;
        public void Dispose()
        {
            list.Clear();
            GC.SuppressFinalize(this);
        }
    }
    public class Lake : IEnumerable<int>
    {
        List<int> list;

        public Lake(List<int> list)
        {
            this.list = list;
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new LakeEnumerator(list);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
