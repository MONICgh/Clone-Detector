using NUnit.Framework;

namespace MergeSort
{
    internal class MergeSortTest
    {
        [Test]
        public void Test1()
        {
            MergeSort mrg = new(3);
            int[] array = new int[] { 7, 2, 1, 15, 24, 1, 3 };
            mrg.SortWaitAll(array);

            int[] answer = new int[] { 1, 1, 2, 3, 7, 15, 24 };
            for (int i = 0; i < array.Length; i++)
            {
                Assert.True(array[i] == answer[i]);
            }
        }

        [Test]
        public void Test2()
        {
            MergeSort mrg = new(7);
            int[] array = new int[] { 5, 4, 3, 2, 1 };
            mrg.SortWaitAll(array);

            int[] answer = new int[] { 1, 2, 3, 4, 5 };
            for (int i = 0; i < array.Length; i++)
            {
                Assert.True(array[i] == answer[i]);
            }
        }

        [Test]
        public void Test3()
        {
            MergeSort mrg = new(2);
            int[] array = new int[] { 100, 15, 24, 26, 1, 11, 108, 25, 2 };
            mrg.SortWaitAll(array);

            int[] answer = new int[] { 1, 2, 11, 15, 24, 25, 26, 100, 108 };
            for (int i = 0; i < array.Length; i++)
            {
                Assert.True(array[i] == answer[i]);
            }
        }

        [Test]
        public void Test4()
        {
            MergeSort mrg = new(3);
            int[] array = new int[] { 7, 2, 1, 15, 24, 1, 3 };
            mrg.SortWithoutWait(array);

            int[] answer = new int[] { 1, 1, 2, 3, 7, 15, 24 };
            for (int i = 0; i < array.Length; i++)
            {
                Assert.True(array[i] == answer[i]);
            }
        }

        [Test]
        public void Test5()
        {
            MergeSort mrg = new(7);
            int[] array = new int[] { 5, 4, 3, 2, 1 };
            mrg.SortWithoutWait(array);

            int[] answer = new int[] { 1, 2, 3, 4, 5 };
            for (int i = 0; i < array.Length; i++)
            {
                Assert.True(array[i] == answer[i]);
            }
        }

        [Test]
        public void Test6()
        {
            MergeSort mrg = new(2);
            int[] array = new int[] { 100, 15, 24, 26, 1, 11, 108, 25, 2 };
            mrg.SortWithoutWait(array);

            int[] answer = new int[] { 1, 2, 11, 15, 24, 25, 26, 100, 108 };
            for (int i = 0; i < array.Length; i++)
            {
                Assert.True(array[i] == answer[i]);
            }
        }
    }
}
