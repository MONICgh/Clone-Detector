using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using static Lab15.MergeSort;

namespace Lab15
{
    public static class MergeSort
    {
        public class Bound
        {
            public int begin { get; set; }
            public int end { get; set; }
        }

        public static Bound GetMinFromOffsets(int[] array, List<Bound> offsets)
        {
            Bound idx = offsets[0];
            foreach (var offset in offsets)
            {
                if (offset.begin >= offset.end)
                    continue;

                if (idx.begin >= idx.end
                    || array[offset.begin] < array[idx.begin])
                {
                    idx = offset;
                }
            }
            return idx;
        }

        public static void Insert(int[] array, int[] array_copy, Bound offset, ref int array_elem_count)
        {
            int idx = 0;
            while (offset.begin < offset.end)
            {
                int k = array_copy[offset.begin];
                if (idx == array_elem_count)
                {
                    array[idx++] = k;
                    offset.begin++;
                    array_elem_count++;
                    continue;
                }
                if (array[idx] < k)
                {
                    idx++;
                    continue;
                }
                // here, k (aka inserted value) is less than array[idx]
                // Insertion
                int insert_idx = idx++;
                array_elem_count++;
                offset.begin++;
                while (insert_idx != array_elem_count)
                {
                    int tmp = array[insert_idx];
                    array[insert_idx++] = k;
                    k = tmp;
                }
            }
        }

        public static void Mergesort(int[] array, int thread_num, bool with_intermediate_sort)
        {
            int[] array_copy = new int[array.Length];
            array.CopyTo(array_copy, 0);
            int k = Math.Min(array.Length, thread_num);
            int default_length = array.Length / k;

            List<Bound> bounds = new List<Bound>();
            for (int i = 0; i < k; ++i)
            {
                bounds.Add(new Bound());
                bounds[i].begin = i * default_length;
                bounds[i].end = Math.Min(array_copy.Length, bounds[i].begin + default_length);
            }


            List<Task> tasks = new List<Task>();
            for (int i = 0; i < k; ++i)
            {
                Action<object> sort = (object obj) =>
                {
                    var bound = (Bound)obj;
                    Array.Sort(array_copy, bound.begin, bound.end - bound.begin);
                    Task.Delay(100);
                };
                tasks.Add(new Task(sort, bounds[i]));
            }
            foreach(var t in tasks)
                t.Start();


            if (with_intermediate_sort)
            {
                //return;
                int result_elem_count = 0;
                while (tasks.Count > 0)
                {
                    var t = Task.WaitAny(tasks.ToArray());
                    tasks.Remove(tasks[t]);
                    var b = bounds[t];
                    bounds.Remove(b);

                    Insert(array, array_copy, b, ref result_elem_count);
                }

                // TODO
            }
            else
            {
                Task.WaitAll(tasks.ToArray());


                int result_elem_count = 0;
                while (result_elem_count < array.Length)
                {
                    var new_idx = GetMinFromOffsets(array_copy, bounds);
                    array[result_elem_count++] = array_copy[new_idx.begin++];
                }
            }
        }
    }
}
