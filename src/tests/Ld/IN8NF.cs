using System;

namespace HW_03
{

    public static class TwoListsSolver
    {
        private static int GetLength<T>(Node<T> list)
        {
            if (list == null)
                return 0;
            return GetLength(list.Next) + 1;
        }

        public static Node<T> GetFirstMatch<T>(Node<T> list1, Node<T> list2)
        {
            var len1 = GetLength(list1);
            var len2 = GetLength(list2);

            var minLen = Math.Min(len1, len2);
            for (var i = 0; i < len1 - minLen; i++)
            {
                list1 = list1.Next;
            }
            for (var i = 0; i < len2 - minLen; i++)
            {
                list2 = list2.Next;
            }
            while (list1 != list2)
            {
                list1 = list1.Next;
                list2 = list2.Next;
            }
            return list1;
        }
    }
}
